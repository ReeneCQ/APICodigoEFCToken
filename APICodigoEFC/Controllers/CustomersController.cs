using APICodigoEFC.Models;
using APICodigoEFC.Request;
using APICodigoEFC.Response;
using APICodigoEFC.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CodigoContext _context;
        public CustomersController(CodigoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Customer> GetByFilters(string? name, string? documentNumber)
        {
            IQueryable<Customer> query = _context.Customers.Where(x => x.IsActive);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));
            if (!string.IsNullOrEmpty(documentNumber))
                query = query.Where(x => x.DocumentNumber.Contains(documentNumber));

            //recien busca en la base de datos
            return query.ToList();
        }

        [HttpPost]
        public void Insert([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        [HttpPut]
        public void Update([FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpPut]
        public ResponseBase UpdateName([FromBody] CustomerUpdateRequest request)
        {
            ResponseBase response = new ResponseBase();

            try
            {

                var customer = _context.Customers.Find(request.Id);
                if (customer == null)
                {
                    response.Code = -1001;
                    response.Message = ValidationsValues.ExistCustomer;
                    return response;
                }
                customer.Name = request.Name;
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();

                response.Message = ValidationsValues.CorrectUpdate;

                return response;

            }
            catch (Exception ex)
            {
                //Write log
                response.Message = ValidationsValues.GeneralError;
                response.Code = -1000;
                return response;
            }


        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Eliminación Física  
            //_context.Customers.Remove(customer);

            var customer = _context.Customers.Find(id);
            customer.IsActive = false;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }



    }
}
