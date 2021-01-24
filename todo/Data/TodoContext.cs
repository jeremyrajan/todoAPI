using System;
using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opt): base(opt)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
