using Cleverti.Assessment.Application.Interfaces;
using Cleverti.Assessment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cleverti.Assessment.API.Controllers
{
    
    [Route("todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoAppService _service;

        public TodoController(ITodoAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Find() => Ok(await _service.FindAll());

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindOne(int id) => Ok(await _service.FindById(id));

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert(Todo todo)
        {
            await _service.Add(todo);
            return Ok(todo);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update(Todo todo)
        {
            await _service.Update(todo);
            return Ok(todo);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);
            return Ok();
        }
    }
}
