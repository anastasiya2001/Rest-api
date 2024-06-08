using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PassportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{series}/{number}")]
        public IActionResult GetPassportData(string series, string number)
        {
            var passportData = _context.PassportDatas.FirstOrDefault(p => p.PassportSeries == series && p.PassportNumber == number);
            if (passportData != null)
            {
                return Ok(passportData);
            }
            return NotFound();
        }
    }
}
