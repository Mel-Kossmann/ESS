using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        DataAccessLayer.DBc.ESSContext db = new DataAccessLayer.DBc.ESSContext();

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var source = db.Employees
                .Select(p => new DataAccessLayer.DTO.Employee
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    Address = p.Address,
                    Salary = p.Salary,
                    CompanyId = p.CompanyId
                });

                return Ok(await DataSourceLoader.LoadAsync(source, loadOptions));
            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Could not retrieve employees.");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            try
            {
                var Obj = new DataAccessLayer.DBc.Employee();
                JsonConvert.PopulateObject(values, Obj);

                var validate = db.Employees.Where(e =>
                   e.Name == Obj.Name
                   && e.Surname == Obj.Surname
                   && e.Email == Obj.Email
                   && e.Address == Obj.Address
                ).FirstOrDefault();

                if (validate != null)
                {
                    return BadRequest("The employee already exists.");
                }

                db.Employees.Add(Obj);
                await db.SaveChangesAsync();

                return Ok(Obj.Id);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Employee not added.");
            }
           
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                var Obj = await db.Employees.FirstOrDefaultAsync(i => i.Id == key);

                if (Obj == null) return StatusCode(409, "not found");
                JsonConvert.PopulateObject(values, Obj);

                var validate = db.Employees.Where(e =>
                    e.Name == Obj.Name
                    && e.Surname == Obj.Surname
                    && e.Email == Obj.Email
                    && e.Address == Obj.Address
                    && e.Id != Obj.Id
                ).FirstOrDefault();

                if (validate != null)
                {
                    return BadRequest("The employee already exists.");
                }

                await db.SaveChangesAsync();
                return Ok(Obj.Id);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Employee not updated.");
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int key)
        {
            try
            {
                var Obj = await db.Employees.FirstOrDefaultAsync(e => e.Id == key);
                if (Obj == null) return StatusCode(409, "Not found.");

                db.Employees.Remove(Obj);
                await db.SaveChangesAsync();

                return Ok("Employee Deleted.");

            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Employee not deleted.");
            }

        }
    }
}
