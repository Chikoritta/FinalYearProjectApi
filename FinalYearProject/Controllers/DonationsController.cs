using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DonationsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public DonationsController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetDonations()
        {
            var donations = _repository.Donation.GetAll(false);

            return Ok(new
            {
                Donations = donations
            });
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var donation = _repository.Donation.GetDonationById(id , false);
            return Ok(new
            {
                Donation = donation
            });
        }
        
         [HttpPost]
         public IActionResult Post([FromBody] Donation donation)
        {
        _repository.Donation.CreateDonation(donation);
        _repository.Save();
        return CreatedAtAction("GetDonations", new {id = donation.Id}, new
        {
        Donation = donation
        });
        }

         [HttpPut("{id}")]
         public IActionResult Put(long id, [FromBody] Donation donation)
         {
             var donationFromDb = _repository.Donation.GetDonationById(id, true);

             if (donationFromDb == null)
             {
                 return NotFound();
             }

             donationFromDb.StatusId = donation.StatusId;
             donationFromDb.CurrentCollected = donation.CurrentCollected;   
             donationFromDb.ReceiptUrl = donation.ReceiptUrl;
             donationFromDb.Target = donation.Target;
             donationFromDb.Description = donation.Description;
             _repository.Save();

             return NoContent();
         }

         [HttpDelete("{id}")]
         public IActionResult Delete(long id)
         {
             var donation = _repository.Donation.GetDonationById(id,false);
             if (donation == null)
             {
                 return NoContent();
             }
             _repository.Donation.DeleteDonation(donation);
             _repository.Save();

             return NoContent();
         }
    }
}