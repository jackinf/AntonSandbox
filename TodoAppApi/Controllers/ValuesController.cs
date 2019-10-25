using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITodoManager todoManager;

        public ValuesController(ITodoManager newTodoManager)
        {
            todoManager = newTodoManager;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return todoManager.GetAllTodos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            TodoItem x = todoManager.GetTodo(id);
            if (x == null)
            {
                return "not found";
            }
            return x.Title;
        }

        // POST api/values 
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var todoItem = new TodoItem();
            todoItem.Id = new Random().Next(10000);
            todoItem.Title = value;
            todoItem.Rating = new Random().Next(1, 5);
            todoManager.AddTodo(todoItem);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            todoManager.UpdateTodo(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            todoManager.DeleteTodo(id);
        }
    }
}
