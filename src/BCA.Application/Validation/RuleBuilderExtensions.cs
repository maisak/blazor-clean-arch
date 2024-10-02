using FluentValidation;

namespace BCA.Application.Validation;

public static class RuleBuilderExtensions
{
	public static IRuleBuilderOptions<T, int> Id<T>(this IRuleBuilder<T, int> builder)
		=> builder.GreaterThan(0);
	public static IRuleBuilderOptions<T, int?> Id<T>(this IRuleBuilder<T, int?> builder)
		=> builder.GreaterThan(0);
}