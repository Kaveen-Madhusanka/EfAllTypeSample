using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
              var Employees =  await _AppDbContext.Employees.Select(s => new Employee()
                {
                    iD = s.iD,
                    Name = s.Name,
                    Address = s.Address,
                    Contact = s.Contact
                }).ToListAsync<Employee>();

                return Ok(Employees);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                var ExsitingEmployee = await _AppDbContext.Employees.Where(x=> x.iD == employee.iD).FirstOrDefaultAsync<Employee>();
                if (ExsitingEmployee != null)
                {
                    ExsitingEmployee.Name = employee.Name;
                    ExsitingEmployee.Address = employee.Address;
                    ExsitingEmployee.Contact = employee.Contact;

                    _AppDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                var ExsistingEmploye = await _AppDbContext.Employees.Where(x => x.iD == id).FirstOrDefaultAsync<Employee>();
                if (ExsistingEmploye != null)
                {
                    _AppDbContext.Entry(ExsistingEmploye).State = EntityState.Deleted;
                    _AppDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                    
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
