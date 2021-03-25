using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Portal;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class Salary
    {
        [TestMethod]
        public async Task SalaryGet()
        {
            Portal.Controllers.SalaryController salary = new Portal.Controllers.SalaryController();
            var result = await salary.Get(new DataSourceLoadOptions());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: GET Test Cases can be run without changing anything
        }
    }
}
