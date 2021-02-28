using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TypesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public TypesController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var types = _repository.Type.GetAll(false);
            return Ok(new
            {
                Types = types
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var type = _repository.Type.GetById(id, false);
            return Ok(new
            {
                Type = type
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserType type)
        {
            _repository.Type.CreateType(type);
            _repository.Save();

            return CreatedAtAction("GetById" , new {  id = type.Id}, new
            {
                Type = type
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id ,[FromBody] UserType type)
        {
            var typeFromDb = _repository.Type.GetById(id, true);

            if (typeFromDb == null)
            {
              return NotFound();
            }

            
            typeFromDb.Type = type.Type;
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var typeFromDb = _repository.Type.GetById(id, false);

            if (typeFromDb == null)
            {
                return NotFound();
            }
            _repository.Type.DeleteType(typeFromDb);
            _repository.Save();

            return NoContent();
        }
 
    }
}