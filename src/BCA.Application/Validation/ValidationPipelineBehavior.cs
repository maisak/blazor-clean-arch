using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BCA.Application.Validation;

public sealed class ValidationPipelineBehavior<TRequest, TResponse>(
	IEnumerable<IValidator<TRequest>> validators,
	ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger)
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : IBaseRequest
{
	public async Task<TResponse> Handle(TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		var failures = new List<ValidationFailure>();
		foreach (var validator in validators)
		{
			var result = await validator.ValidateAsync(request, cancellationToken);
			if (!result.IsValid)
			{
				failures.AddRange(result.Errors);
			}
		}

		if (failures.Count == 0) return await next();

		var name = request.GetType().Name;
		logger.LogWarning("Validation failed for {Request}, failures: {@Failures}",
			name,
			failures.Select(x => x.ErrorMessage));
		throw new ValidationException(failures);
	}
}