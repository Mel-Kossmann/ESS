using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;

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
            var source = db.Companies
                .Select(p => new DataAccessLayer.DTO.Company
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return Ok(await DataSourceLoader.LoadAsync(source, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            var Obj = new DataAccessLayer.DBc.Company();
            JsonConvert.PopulateObject(values, Obj);

            db.Companies.Add(Obj);
            await db.SaveChangesAsync();

            return Ok(Obj.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            var Obj = await db.Companies.FirstOrDefaultAsync(i => i.Id == key);

            if (Obj == null) return StatusCode(409, "not found");

            JsonConvert.PopulateObject(values, Obj);

            await db.SaveChangesAsync();
            return Ok(Obj.Id);
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
                return BadRequest("Company not deleted");
            }

        }
    }
}
