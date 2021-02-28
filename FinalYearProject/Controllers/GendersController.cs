using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GendersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public GendersController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetGender()
        {
            var genders = _repository.Gender.GetAll(false);
            return Ok(new
            {
                Genders = genders
            });
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var gender = _repository.Gender.GetById(id, false);
            return Ok(new
            {
                Gender = gender
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Gender gender)
        {
            _repository.Gender.CreateGender(gender);
            _repository.Save();

            return CreatedAtAction("GetById", new {id = gender.Id}, new
            {
                Gender = gender
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Gender gender)
        {
            var genderFromDb = _repository.Gender.GetById(id, true);

            if (genderFromDb == null)
            {
                return NotFound();
            }

            genderFromDb.Type = gender.Type;
            _repository.Save();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteGender(long id)
        {
            var genderFromDb = _repository.Gender.GetById(id, false);

            if (genderFromDb == null)
            {
                return NoContent();
            }

            _repository.Gender.DeleteGender(genderFromDb);
            _repository.Save();

            return NoContent();
        }
    }
}