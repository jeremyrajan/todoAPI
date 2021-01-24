using System;
using System.Collections.Generic;
using todo.Models;

namespace todo.Data
{
    public interface ITodoRepo
    {
        bool SaveChanges();

        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(int id);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
    }
}
