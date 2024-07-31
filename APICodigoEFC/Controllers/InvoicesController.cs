using Infraestructure.Contexts;
using Domain.Models;
using Peticioness.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoicesService _service;

        public InvoicesController(CodigoContext context)
        {
            _service = new InvoicesService(context);
        }

        [HttpGet]
        public List<Invoice> GetByFilters(string? number)
        {
            return _service.GetByFilters(number);
        }

        [HttpPost]
        public void Insert([FromBody] InvoiceInsertRequest request)
        {
            // Convertir el request a modelo Invoice
            Invoice invoice = new Invoice
            {
                Number = request.Number,
                Description = request.Description,
                CustomerID = request.CustomerID,
                IsActive = true
            };

            _service.Insert(invoice);
        }
    }
}