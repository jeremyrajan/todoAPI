using System;
using AutoMapper;
using todo.Dtos;
using todo.Models;

namespace todo.Profiles
{
    public class TodosProfile : Profile
    {
        public TodosProfile()
        {
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
            CreateMap<Todo, TodoUpdateDto>();
            CreateMap<Todo, TodoDeleteDto>();
        }
    }
}
