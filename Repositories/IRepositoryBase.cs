using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Repositories
{
    public interface IRepositoryBase<T>
    {
        public Task<ActionResult<IEnumerable<T>>> GetAll();
        public Task<ActionResult<T>> GetById(long id,  Expression<Func<T, bool>> expression);
        public Task<int> Post(T t);
        public Task<IActionResult> Put(long id, T t);
        public Task<IActionResult> Delete(long id);
    }
}