using System;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<T> GetAll()
        {
            return repository.Set<T>().AsNoTracking();
        }

        public T GetById(int id, Expression<Func<T, bool>> expression)
        {
            var todoItem = repository.Set<T>().FirstOrDefault(expression);

            if (todoItem == null)
            {
                return null;
            }

            return todoItem;
        }

        public int Post(T t)
        {
            repository.Set<T>().Add(t);
            return repository.SaveChanges();
        }

        public int Put(int id, T t)
        {
            repository.Entry(t).State = EntityState.Modified;

            try
            {
                return repository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public int Delete(int id)
        {
            var todoItem = repository.Set<T>().Find(id);
            if (todoItem == null)
            {
                return 0;
            }

            repository.Set<T>().Remove(todoItem);
            return repository.SaveChanges();
        }
    }
}