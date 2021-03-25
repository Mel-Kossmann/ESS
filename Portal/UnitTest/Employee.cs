using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Portal;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class Employee
    {
        [TestMethod]
        public async Task EmployeeGet()
        {
            Portal.Controllers.EmployeeController employee = new Portal.Controllers.EmployeeController();
            var result = await employee.Get(new DataSourceLoadOptions());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: GET Test Cases can be run without changing anything
        }

        [TestMethod]
        public async Task EmployeePost()
        {
            Portal.Controllers.EmployeeController employee = new Portal.Controllers.EmployeeController();
            DataAccessLayer.DTO.Employee classValue = new DataAccessLayer.DTO.Employee();
            classValue.Name = "Melody";
            classValue.Surname = "Kossmann";
            classValue.Email = "Melody.Kossmann@s4.co.za";
            classValue.Salary = 14500;
            classValue.Address = "33 Whyteleaf Drive";
            classValue.CompanyId = 80;

            string json = JsonConvert.SerializeObject(classValue);
            var result = await employee.Post(json);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: The test will fail if you add an employee that already exist (multiple variables are checked for the employee)
            //What to change: all the classValues above
            //What to add: You need to know a companyID to add an employee
            //Run the test
        }

        [TestMethod]
        public async Task EmployeePut()
        {
            Portal.Controllers.EmployeeController employee = new Portal.Controllers.EmployeeController();
            DataAccessLayer.DTO.Employee classValue = new DataAccessLayer.DTO.Employee();
            classValue.Id = 1010;
            classValue.Name = "Charne";
            classValue.Surname = "Kossmann";
            classValue.Email = "Melody.Kossmann@s4.co.za";
            classValue.Salary = 14500;
            classValue.Address = "33 Whyteleaf Drive";
            classValue.CompanyId = 80;
            string json = JsonConvert.SerializeObject(classValue);
            var result = await employee.Put(1010,json);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE: The test will fail if you add an employee that already exist (multiple variables are checked for the employee)
            //What to change: all the classValues above
            //What to add: You will need the id of the row you are updating, changing the following:
            //classValues, first parameter in the put, You need to know a companyID to add an employee
            //employee.Put(rowID,json)
            //Run the test
        }

        [TestMethod]
        public async Task EmployeeDelete()
        {
            Portal.Controllers.EmployeeController employee = new Portal.Controllers.EmployeeController();
            var result = await employee.Delete(1009);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            //NOTE
            //Best employee to delete: the one you added in the unit test post
            //What to change: You will need the id of the row you want to delete, change the first parameter in the delete
            //Run the test
        }
    }
}
