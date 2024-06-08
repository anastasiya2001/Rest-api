using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlacklistController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{series}/{number}")]
        public IActionResult CheckBlacklist(string series, string number)
        {
            var person = _context.BlacklistedPeople.FirstOrDefault(p => p.PassportSeries == series && p.PassportNumber == number);
            if (person != null)
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
