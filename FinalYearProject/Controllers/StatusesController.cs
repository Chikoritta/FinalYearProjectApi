using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class StatusesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public StatusesController(IRepositoryManager repository )
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var statuses = _repository.Status.GetAll(false);
            return Ok(new
            {
                Statuses = statuses
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var status = _repository.Status.GetById(id, false);

            return Ok(new
            {
                Status= status
            });
        }

        [HttpPost]
        public IActionResult Post( [FromBody] DonationStatus status)
        {
            
            _repository.Status.CreateStatus(status);
            _repository.Save();

            return CreatedAtAction("GetById", new { id = status.Id} , new
                {
                    Status = status
                }
            );
        }


        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] DonationStatus status)
        {
            var statusFromDb = _repository.Status.GetById(id, true);

            if (statusFromDb == null)
            {
                return NotFound();
            }

            statusFromDb.Name = status.Name;
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var status = _repository.Status.GetById(id, false);

            if (status == null)
            {
                return NotFound();
            }

            _repository.Status.DeleteStatus(status);
            _repository.Save();
            return NoContent();
        }

    }
    
}