using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
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
    public class CompanyController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        DataAccessLayer.DBc.ESSContext db = new DataAccessLayer.DBc.ESSContext();

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var source = db.Companies
                    .Select(p => new DataAccessLayer.DTO.Company
                    {
                        Id = p.Id,
                        Name = p.Name
                    });

                return Ok(await DataSourceLoader.LoadAsync(source, loadOptions));
            }catch(Exception e)
            {
                logger.Error(e);
                return BadRequest("Could not retrieve companies.");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            try
            {
                var Obj = new DataAccessLayer.DBc.Company();
                JsonConvert.PopulateObject(values, Obj);
                var validate = db.Companies.Where(c => c.Name == Obj.Name).FirstOrDefault();
                if (validate != null)
                {
                    return BadRequest("Company name already exists.");
                }

                db.Companies.Add(Obj);
                await db.SaveChangesAsync();

                return Ok(Obj.Id);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Company not added");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                var Obj = await db.Companies.FirstOrDefaultAsync(i => i.Id == key);

                if (Obj == null) return StatusCode(409, "not found");

                JsonConvert.PopulateObject(values, Obj);
                var validate = db.Companies.Where(c => c.Name == Obj.Name && c.Id != Obj.Id).FirstOrDefault();

                if (validate != null)
                {
                    return BadRequest("Company name already exists.");
                }

                await db.SaveChangesAsync();
                return Ok(Obj.Id);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Company not updated");
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int key)
        {
            try
            {
                var Obj = await db.Companies.FirstOrDefaultAsync(e => e.Id == key);
                if (Obj == null) return StatusCode(409, "Not found");

                db.Companies.Remove(Obj);
                await db.SaveChangesAsync();

                return Ok("Company Deleted");

            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("The Company not deleted. The company has employees.");
            }

        }
    }
}
