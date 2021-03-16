using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repositories;

namespace basic_crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly RepositoryBase<Project> repository;

        public ProjectsController(RepositoryBase<Project> repository)
        {
            this.repository = repository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            // return await _context.Projects.ToListAsync();
            var projects = await repository.GetAll().ToListAsync();
            return projects;
        }

        // GET: api/TodoItems/5
        //If no item matches the requested ID, the method returns a 404 status NotFound error code.
        //Otherwise, the method returns 200 with a JSON response body. Returning item results in an HTTP 200 response.
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            // var project = await _context.Projects.FindAsync(id);
            var project = repository.GetById(id, project => project.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // This requires the whole item to be sent in the request
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutProject(long id, Project project)
        // {
        //     if (id != project.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(project).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!TodoItemExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Project> PostProject(Project project)
        {
            // _context.Projects.Add(project);
            // await _context.SaveChangesAsync();
            repository.Post(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // DELETE: api/TodoItems/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteProject(long id)
        // {
        //     var project = await _context.Projects.FindAsync(id);
        //     if (project == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Projects.Remove(project);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool TodoItemExists(long id)
        // {
        //     return _context.Projects.Any(e => e.Id == id);
        // }
    }
}
