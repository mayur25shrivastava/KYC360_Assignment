using Microsoft.AspNetCore.Mvc;
using KYC360API.Models;
using KYC360API.Services;
using System.Collections.Generic;

namespace KYC360API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private readonly MockDatabaseService _mockDatabaseService;

        public EntitiesController(MockDatabaseService mockDatabaseService)
        {
            _mockDatabaseService = mockDatabaseService;
        }

        // GET: api/entities
        [HttpGet]
        public IActionResult GetEntities()
        {
            var entities = _mockDatabaseService.GetEntities();
            return Ok(entities);
        }

        // GET: api/entities/5
        [HttpGet("{id}")]
        public IActionResult GetEntity(string id)
        {
            var entity = _mockDatabaseService.GetEntityById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // POST: api/entities
        [HttpPost]
        public IActionResult CreateEntity([FromBody] Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mockDatabaseService.AddEntity(entity);

            return CreatedAtAction(nameof(GetEntity), new { id = entity.Id }, entity);
        }

        // PUT: api/entities/5
        [HttpPut("{id}")]
        public IActionResult UpdateEntity(string id, [FromBody] Entity entity)
        {
            if (id != entity.Id || !_mockDatabaseService.EntityExists(id))
            {
                return BadRequest();
            }

            _mockDatabaseService.UpdateEntity(entity);

            return NoContent();
        }

        // DELETE: api/entities/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEntity(string id)
        {
            var entity = _mockDatabaseService.GetEntityById(id);

            if (entity == null)
            {
                return NotFound();
            }

            _mockDatabaseService.DeleteEntity(id);

            return NoContent();
        }
    }
}
