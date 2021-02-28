using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDonationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public UserDonationController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userDonation = _repository.UserDonation.GetAll(false);
            return Ok(new
            {
                UserDonation = userDonation
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var userDonation = _repository.UserDonation.GetById(id, false);
            return Ok(new
            {
                UserDonation = userDonation
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDonation userDonation)
        {
            _repository.UserDonation.CreateUserDonation(userDonation);
            _repository.Save();

            return CreatedAtAction("GetById", new { id = userDonation.Id}, new
            {
                UserDonation =userDonation
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UserDonation userDonation)
        {
            var userDonationFromDb = _repository.UserDonation.GetById(id, true);

            if (userDonationFromDb == null)
            {
                return NotFound();
            }
            userDonationFromDb.Amount = userDonation.Amount;
            _repository.Save();
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var userDonationFromDb = _repository.UserDonation.GetById(id, true);

            if (userDonationFromDb == null)
            {
                return NotFound();
            }
            _repository.UserDonation.DeleteUserDonation(userDonationFromDb);
            _repository.Save();
        
            return NoContent();
        }
    }
}