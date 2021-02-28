using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public UsersController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repository.User.GetAll(false);
            return Ok(new
            {
                Users = users
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var user = _repository.User.GetById(id, false);
            return Ok(new
            {
                User = user
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var userFromDb = _repository.User.GetByUsername(user.Username, false);

            if (userFromDb != null)
            {
                return Conflict($"the username '{user.Username}' is already taken");
            }
            
            _repository.User.CreateUser(user);
            _repository.Save();
            return CreatedAtAction("GetById", new {id = user.Id},
                new
                {
                    User = user
                }
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody] User user)
        {
            var userFromDb = _repository.User.GetById(id, true);

            if (userFromDb == null)
            {
                return NotFound();
            }
            userFromDb.Name = user.Name;
            userFromDb.AvatarUrl = user.AvatarUrl;
            userFromDb.Email = user.Email;
            userFromDb.BirthDate = user.BirthDate;
            userFromDb.MobileNumber = user.MobileNumber;
            userFromDb.GenderType = user.GenderType;
            userFromDb.UserType = user.UserType;
            userFromDb.Longitude = user.Longitude;   
            userFromDb.Latitude = user.Latitude;
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            var userFromDb = _repository.User.GetById(id, false);

            if (userFromDb == null)
            {
                return NotFound();
            }

            _repository.User.DeleteUser(userFromDb);
            _repository.Save();

            return NoContent();
        }
    }
}