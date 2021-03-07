using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    // TODO: Implement all IRepositoryBase functions
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryContext repository { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repository = repositoryContext;
        }

        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return await repository.Set<T>().ToListAsync();
        }

        public async Task<ActionResult<T>> GetById(long id, Expression<Func<T, bool>> expression)
        {
            var todoItem = await repository.Set<T>().FirstOrDefaultAsync(expression);

            if (todoItem == null)
            {
                return null;
            }

            return todoItem;
        }

        public async Task<int> Post(T t)
        {
            repository.Set<T>().Add(t);
            return await repository.SaveChangesAsync();
        }

        public async Task<IActionResult> Put(long id, T t)
        {
            repository.Entry(t).State = EntityState.Modified;

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            }

            return null;
        }

        public async Task<IActionResult> Delete(long id)
        {
            var todoItem = await repository.Set<T>().FindAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            repository.Set<T>().Remove(todoItem);
            await repository.SaveChangesAsync();

            return null;
        }
    }
}