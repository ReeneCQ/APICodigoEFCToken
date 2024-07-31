using Domain.Models;
using APICodigoEFC.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using APICodigoEFC.Utility;
using APICodigoEFC.Request;
using Infraestructure.Contexts;
using Services.Services;


namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly DetailsService _service;

        public DetailsController(CodigoContext context)
        {
            _service = new DetailsService(context);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Detail detail)
        {
            _service.Insert(detail);
            return Ok(new ResponseBase
            {
                Code = 200,
                Message = "Detail inserted successfully"
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var details = _service.Get();
            return Ok(details);
        }

        [HttpGet]
        public IActionResult GetByFilters(string? customerName, string? invoiceNumber)
        {
            var details = _service.GetByFilters(customerName, invoiceNumber);
            return Ok(details);
        }

        [HttpGet]
        public IActionResult GetByInvoiceNumber(string? invoiceNumber)
        {
            var response = _service.GetByInvoiceNumber(invoiceNumber);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetByInvoiceNumber2(string? invoiceNumber)
        {
            var response = _service.GetByInvoiceNumber2(invoiceNumber);
            return Ok(response);
        }
    }
}

