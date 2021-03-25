using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        DataAccessLayer.DBc.ESSContext db = new DataAccessLayer.DBc.ESSContext();

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var source = db.Employees.Join(db.Companies, p => p.CompanyId, q => q.Id, (p, q) => new { Employees = p, Companies = q })
                  .Where(s => s.Employees.CompanyId == s.Companies.Id)
                  .GroupBy(pp => new { pp.Companies.Name })
                  .Select(ss => new { CompanyName = ss.Key.Name, aveSalary = Math.Round((decimal)ss.Average(a => a.Employees.Salary), 2) });
                return Ok(await DataSourceLoader.LoadAsync(source, loadOptions));
            }
            catch(Exception e)
            {
                logger.Error(e);
                return BadRequest("Could not calculate the average salary per company.");
            }           
        }

        //This is an extra GET that can be used with postman
        //YOURURL/api/Salary/GetAverageSalary?CompanyId=ID
        //ID = anything between 1 - 200 (pre-loaded companies)
        [HttpGet("GetAverageSalary")]
        public object GetAverageSalary(int CompanyId)
        {
            try
            {
                var source = db.Employees.Join(db.Companies, p => p.CompanyId, q => q.Id, (p, q) => new { Employees = p, Companies = q })
                  .Where(s => s.Employees.CompanyId == CompanyId)
                  .Select(a => a.Employees.Salary);
                return Ok(Math.Round((decimal)source.Average(),2));
            }
            catch (Exception e)
            {
                logger.Error(e);
                return BadRequest("Could not retrieve the average salary.");
            }
        }
    }
}
