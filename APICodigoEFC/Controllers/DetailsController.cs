using APICodigoEFC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly CodigoContext _context;

        public DetailsController(CodigoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert([FromBody] Detail detail)
        {
            _context.Details.Add(detail);
            _context.SaveChanges();
        }
    }
}
