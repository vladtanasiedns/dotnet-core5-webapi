using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Dtos;
using TodoApi.Repositories;

namespace basic_crud_api.Controllers
{
    [Route("api/[controller]")] // The route the controller will respond to [controller] is replaced by the controller name
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        // The context which forms a connection to the database so we can query
        private readonly RepositoryBase<TodoItem> repository;

        public TodoItemsController(RepositoryBase<TodoItem> repository)
        {
            this.repository = repository;
        }

        // GET: api/TodoItems request method annotation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            var result = await repository.GetAll().ToListAsync();
            var dtoList = new List<TodoItemDto>();

            foreach (var item in result)
            {

                dtoList.Add(new TodoItemDto(item.Id, item.Name, item.ProjectId, item.IsComplete));
            }

            return dtoList;
        }

        // GET: api/TodoItems/5
        //If no item matches the requested ID, the method returns a 404 status NotFound error code.
        //Otherwise, the method returns 200 with a JSON response body. Returning item results in an HTTP 200 response.
        //"{id:guid}" sets a constraint to only receive a guid as the id parameter
        [HttpGet("{id}")]
        // ActionResult returns permits more than one type to be returned from the method
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            var todoItem = repository.GetById(id, t => t.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            repository.Post(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // This requires the whole item to be sent in the request
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            int response = repository.Put(id, todoItem);

            if (response < 1)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var todoItem = repository.GetById(id, t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            repository.Delete(id);

            return NoContent();
        }

        private bool TodoItemExists(int id)
        {
            var todoItem = repository.GetById(id, t => t.Id == id);

            if (todoItem == null)
            {
                return false;
            }

            return true;
        }
    }
}
