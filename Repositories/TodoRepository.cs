using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoRepository : RepositoryBase<TodoItem>, ITodoRepository
    {
        public TodoRepository(RepositoryContext context) : base(context)
        {
        }
    }
}