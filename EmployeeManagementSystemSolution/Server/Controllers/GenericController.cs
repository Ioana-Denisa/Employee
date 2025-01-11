using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T>(IGenericRepository<T> genericRepository) : ControllerBase where T : class
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll() =>Ok(await genericRepository.GetAll());
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid request sent");
            return Ok(await genericRepository.DeleteByID(id));
        }
        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (id <= 0) return BadRequest("Invalid request sent");
            return Ok(await genericRepository.GetByID(id));
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(T model)
        {
            if (model == null) return BadRequest("Bad request made");
            return Ok(await genericRepository.Insert(model));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(T model)
        {
            if (model == null) return BadRequest("Bad request made");
            return Ok(await genericRepository.Update(model));
        }
    }
}
