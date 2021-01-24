using System;
using System.Collections.Generic;
using todo.Models;

namespace todo.Data
{
    public class MockTodoRepo : ITodoRepo
    {
        public void CreateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            var todos = new List<Todo>
            {
                new Todo { Id = 0, Name = "test1", Author = "Jeremy", Done = false },
                new Todo { Id = 1, Name = "test2", Author = "Jeremy", Done = false },
                new Todo { Id = 2, Name = "test3", Author = "Jeremy", Done = false }
            };

            return todos;
        }

        public Todo GetTodoById(int id)
        {
            return new Todo { Id = 0, Name = "test", Author = "Jeremy", Done = false };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodo(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
