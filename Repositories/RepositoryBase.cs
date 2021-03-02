using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Repositories
{
    // TODO: Implement all IRepositoryBase functions
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryContext repositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repository = repositoryContext;
        }

        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return await repositoryContext.Set<T>().ToListAsync();
        }
    }
}