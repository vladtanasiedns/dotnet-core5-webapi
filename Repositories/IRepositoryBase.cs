using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Repositories
{
    public interface IRepositoryBase<T>
    {
        public IQueryable<T> GetAll();
        public T GetById(int id,  Expression<Func<T, bool>> expression);
        public int Post(T t);
        public int Put(int id, T t);
        public int Delete(int id);
    }
}