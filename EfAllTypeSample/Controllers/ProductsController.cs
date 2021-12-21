using EfAllTypeSample.Data;
using EfAllTypeSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EfAllTypeSample.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Productstbl products)
        {
            try
            {
                await _context.Productstbl.AddAsync(products);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
