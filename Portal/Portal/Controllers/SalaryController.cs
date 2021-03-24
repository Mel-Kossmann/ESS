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
            var source = db.Employees.Join(db.Companies, p => p.CompanyId, q => q.Id, (p, q) => new { Employees = p, Companies = q })
                   .Where(s => s.Employees.CompanyId == s.Companies.Id)
                   .GroupBy(pp => new { pp.Companies.Name })
                   .Select(ss => new { CompanyName = ss.Key.Name, aveSalary = Math.Round((decimal)ss.Average(a => a.Employees.Salary), 2) });
            return Ok(await DataSourceLoader.LoadAsync(source, loadOptions));
        }
    }
}
