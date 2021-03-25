using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Portal;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class Company
    {
        [TestMethod]
        public async Task CompanyGet()
        {
            Portal.Controllers.CompanyController company = new Portal.Controllers.CompanyController();
            var result = await company.Get(new DataSourceLoadOptions());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: GET Test Cases can be run without changing anything
        }

        [TestMethod]
        public async Task CompanyPost()
        {
            Portal.Controllers.CompanyController company = new Portal.Controllers.CompanyController();
            DataAccessLayer.DTO.Company classValue = new DataAccessLayer.DTO.Company();
            classValue.Name = "Test";
            string json = JsonConvert.SerializeObject(classValue);
            var result = await company.Post(json);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: The test will fail if you add a Company name that already exist.
            //What to change: classValue.Name
            //Run the test
        }

        [TestMethod]
        public async Task CompanyPut()
        {
            Portal.Controllers.CompanyController company = new Portal.Controllers.CompanyController();
            DataAccessLayer.DTO.Company classValue = new DataAccessLayer.DTO.Company();
            classValue.Name = "Test 2";
            classValue.Id = 206;
            string json = JsonConvert.SerializeObject(classValue);
            var result = await company.Put(206, json);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: The test will fail if you add a Company name that already exist.
            //What to change: classValue.Name
            //What to add: You will need the id of the row you are updating, change the following"
            //classValue.Name and first parameter in the put
            //company.Put(rowID,json)
            //Run the test
        }

        [TestMethod]
        public async Task CompanyDelete()
        {
            Portal.Controllers.CompanyController company = new Portal.Controllers.CompanyController();
            var result = await company.Delete(206);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: The test will fail if you are trying to delete a company that is linked to an employee
            //Best company to delete: the one you added in the unit test post
            //What to change: You will need the id of the row you want to delete, change the first parameter in the delete
            //Run the test
        }
    }
}
