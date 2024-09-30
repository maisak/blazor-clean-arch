using AutoMapper;
using BCA.Application.Models.Todo;
using BCA.Domain.Entities;

namespace BCA.Application.Mappings;

public class TodoListsProfile : Profile
{
	public TodoListsProfile()
	{
		CreateMap<TodoList, TodoListDto>().ReverseMap();
	}
}