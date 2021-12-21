using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                await _AppDbContext.Employees.AddAsync(employee);
                await _AppDbContext.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
