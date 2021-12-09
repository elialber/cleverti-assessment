using Cleverti.Assessment.Data.Context;
using Cleverti.Assessment.Domain.Entities;
using Cleverti.Assessment.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverti.Assessment.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly MemoryContext _context;

        public TodoRepository(MemoryContext context)
        {
            _context = context;
        }

        public async Task<Todo> Add(Todo todo)
        {
            _context.Todos.Add(todo);
            return todo;
        }

        public async Task<IEnumerable<Todo>> FindAll()
        {
           return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> FindById(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            _context.Todos.Remove(new Todo { Id = id });

        }

        public async Task<Todo> Update(Todo todo)
        {
            _context.Todos.Update(todo);
            return todo;
        }
    }
}
