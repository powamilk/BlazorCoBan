using BlazorCoBan;
using DemoAPIBlazor.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPIBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IRepository<TodoItem> _repository;

        public TodoController(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoViewModel>> Get(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var viewModel = new TodoViewModel { Id = item.Id, Title = item.Title, IsCompleted = item.IsCompleted };
            return Ok(viewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post(TodoItem item)
        {
            await _repository.AddAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TodoItem item)
        {
            if (id != item.Id) return BadRequest();
            await _repository.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
