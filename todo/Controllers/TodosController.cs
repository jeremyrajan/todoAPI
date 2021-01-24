using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using todo.Data;
using todo.Dtos;
using todo.Models;

namespace todo.Controllers
{
    [ApiController]
    [Route("/todos")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepo _repository;
        private readonly IMapper _mapper;

        // for dep injection
        public TodosController(ITodoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //private readonly MockTodoRepo _repository = new MockTodoRepo();

        [HttpGet]
        public ActionResult<IEnumerable<TodoReadDto>> GetAllTodos()
        {
            var todos = _repository.GetAllTodos();

            return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(todos));
        }

        [HttpGet("{id}", Name ="GetTodo")]
        public ActionResult<TodoReadDto> GetTodo(int id)
        {
            var todoItem = _repository.GetTodoById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TodoReadDto>(todoItem));
        }

        [HttpPost]
        public ActionResult<TodoReadDto> CreateTodo(TodoCreateDto todoCreateDto)
        {
            var todoModel = _mapper.Map<Todo>(todoCreateDto);
            _repository.CreateTodo(todoModel);
            _repository.SaveChanges(); // persist

            var todoReadDto = _mapper.Map<TodoReadDto>(todoModel);

            //return Ok(todoReadDto); // raw response

            return CreatedAtRoute(nameof(GetTodo), new { Id= todoReadDto.Id}, todoReadDto); // return location
        }

        [HttpPut("{id}")]
        public ActionResult<TodoReadDto> UpdateTodo(int id, TodoUpdateDto todoUpdateDto)
        {
            var todoModelFromRepo = _repository.GetTodoById(id);

            if (todoModelFromRepo == null)
            {
                return NotFound();
            }

            var todoReadDto = _mapper.Map(todoUpdateDto, todoModelFromRepo);
            _repository.UpdateTodo(todoModelFromRepo);
            _repository.SaveChanges();

            return Ok(todoReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult<TodoReadDto> PartialTodoUpdate(int id, JsonPatchDocument<TodoUpdateDto> patchDoc)
        {
            var todoModelFromRepo = _repository.GetTodoById(id);

            if (todoModelFromRepo == null)
            {
                return NotFound();
            }

            var todoPatch = _mapper.Map<TodoUpdateDto>(todoModelFromRepo);
            patchDoc.ApplyTo(todoPatch, ModelState);

            if (!TryValidateModel(todoPatch))
            {
                return ValidationProblem(ModelState);
            }

            var todoReadDto = _mapper.Map(todoPatch, todoModelFromRepo);

            _repository.UpdateTodo(todoModelFromRepo);
            _repository.SaveChanges();

            return Ok(todoReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult<TodoReadDto> DeleteTodo(int id)
        {
            var todoModelFromRepo = _repository.GetTodoById(id);

            if (todoModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteTodo(todoModelFromRepo);
            _repository.SaveChanges();

            return Ok(todoModelFromRepo);
        }

    }
}
