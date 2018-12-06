using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orangeMartDev.Data;
using orangeMartDev.ViewModel;

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
        public IEnumerable<ProductDto> Get()
        {
            // return context.Products; // ICollection<Review> reviews are coming as null because EF is not able to load the related entities.
            //lets try to update to include the Review Data
            //return context.Products.Include(p => p.Reviews);
            /*
             * The problem here is when we defined the Product class we included a navigation property for Reviews:
             and we also included a navigation property for Product in Review model class.
             and when we try to load the data for related entities it creates a circular object graph.
             As a result of this when the JSON or XML formatter tries to load and serialize the data both throws different exception. 

To overcome this error, we will be using DTO(Data transfer Objects) class to get all data. Add the following new DTO class within Models folder.
             */
            return context.Products.Select(p => new ProductDto
            {
                CategoryName = p.Category.Name,
                Name = p.Name,
                Price = p.Price,
                Reviews = p.Reviews.ToList()
            }).ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id) //Get([FromRoute] string quizId)
        {
            var product = await context.Products
                .Include(p=>p.Category)
                .Include(p=> p.Reviews)
                .FirstOrDefaultAsync(p=>p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            var dto = new ProductDto();
            try
            {
                dto = new ProductDto
                {
                    CategoryName = product.Category.Name,
                    Name = product.Name,
                    Price = product.Price,
                    Reviews = product.Reviews.ToList()
                };
            }
            catch (Exception ex)
            {
                var text = ex;
                throw;
            }

            return Ok(dto); //todo replace category with enum 
            //return dto;
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

/*
  Update-Database -Migration:0 //removes last migration from database
  Remove-Migration //removes last migration from project
  //create new migration (add-migration mig_name)
  //apply changes to DB (update-database)
     */
