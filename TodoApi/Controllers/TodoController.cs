using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        private TodoContext _dbContext;

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _dbContext.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = _dbContext.TodoItems.AsNoTracking().Single(t => t.TodoItemID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            if (item.TodoItemID == null) { item.TodoItemID = Guid.NewGuid().ToString(); }
            _dbContext.TodoItems.Add(item);
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetTodo", new { id = item.TodoItemID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.TodoItemID != id)
            {
                return BadRequest();
            }
            TodoItem todo = _dbContext.TodoItems.Single(t => t.TodoItemID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _dbContext.Update(item);
            _dbContext.SaveChanges();
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] TodoItem item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            TodoItem todo = _dbContext.TodoItems.Single(t => t.TodoItemID == id);
            if (todo == null)
            {
                return NotFound();
            }

            item.TodoItemID = todo.TodoItemID;

            _dbContext.Update(item);
            _dbContext.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            TodoItem todo = _dbContext.TodoItems.Single(t => t.TodoItemID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _dbContext.Remove(id);
            _dbContext.SaveChanges();
            return new NoContentResult();
        }
    }
}
