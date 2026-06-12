using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.DTO;
using LibraryService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudService _fraudService;

        public FraudController(IFraudService fraudService)
        {
            _fraudService = fraudService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fraudes = await _fraudService.GetAll();
            return Ok(fraudes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FraudForm form)
        {
            var fraud = new Fraud
            {
                ImpostorDetails = form.ImpostorDetails,
                ContactInfo = form.ContactInfo,
                Comments = form.Comments
            };

            var createdFraud = await _fraudService.Add(fraud);
            return CreatedAtAction(nameof(GetAll), new { id = createdFraud.Id }, createdFraud);
        }
    }
}
