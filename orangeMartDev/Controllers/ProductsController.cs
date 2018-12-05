using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orangeMartDev.Data;

namespace orangeMartDev.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(string id) //Get([FromRoute] string quizId)
        {
            return context.Products.FirstOrDefault(p => p.Id == Guid.Parse(id));
        }
        
        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            //var prod = context.Products.SingleOrDefault(p => p.Id == product.Id); // goes over aggreate root

            //if (prod == null)
            //{
            //    return NotFound();
            //}
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody]Product product)
        {
            if (Guid.Parse(id) != product.Id)
            {
                return BadRequest();
            }
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(product);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var productToDelete = await context.Products.FindAsync(Guid.Parse(id));
            if (productToDelete is null)
            {
                return NotFound();
            }
            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
