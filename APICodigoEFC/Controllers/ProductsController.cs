using Infraestructure.Contexts;
using Domain.Models;
using Peticioness.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CodigoContext _context;
        public ProductsController(CodigoContext context)
        {
            _context = context;
        }

        [HttpGet]
        // LO HACE PUBLICO ALLOWANONYMUS
        [AllowAnonymous]
        public List<Product> GetByFilters(string? name)
        {
            IQueryable<Product> query = _context.Products.Where(p => p.IsActive);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            return query.OrderBy(x => x.Price).ToList();
        }

        [HttpPost]
        public void Insert([FromBody] ProductInsertRequest request)
        {
            //Convertir el request => Model (Serializar)

            Product product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            _context.Products.Add(product);//Un Modelo
            _context.SaveChanges();
        }
        [HttpPut]
        public void Update([FromBody] Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdatePrice([FromBody] ProductUpdateRequest request)
        {

            var product = _context.Products.Find(request.Id);
            product.Price = request.Price;
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            product.IsActive = false;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
