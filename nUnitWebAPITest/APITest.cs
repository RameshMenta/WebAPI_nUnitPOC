using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI_nUnitPOC.Data;
using WebAPI_nUnitPOC.Services;

namespace nUnitWebAPITest
{
    public class APITest
    {
        EmpService empService = new(); // Initializing EmpService from Web API
        
        private List<Emp> Emps4TestCases = new()
        {
            new Emp { id = 1, name = "Name1", age = 20, salary = 1000 },
            new Emp { id = 2, name = "Name2", age = 30, salary = 2000 },
            // new Emp { id = 3, name = "Name3", age = 40, salary = 3000 } // Intentionally commented here to add this from Setup Method.
        };

        // This method executes before any tests starts run.
        // We can have any no of Setup methods. Execution sequence is top to bottom.
        [SetUp]
        public void Setup()
        {
            Emps4TestCases.Add(new Emp { id = 3, name = "Name3", age = 40, salary = 3000 });
        }

        // Manually passing the test.
        [Test]
        public void PassManually()
        {
            // can be done test case own business login code here...
            Assert.Pass();
        }


        // Get All Employees List and match with EmpService default data.
        [Test]
        public void GetEmps()
        {
            var emps = empService.GetEmps();
            string expectedJson = JsonSerializer.Serialize(Emps4TestCases);
            string actualJson = JsonSerializer.Serialize(emps);
            Assert.AreEqual(expectedJson, actualJson); // We can also use CollectionAssert.AreEqual
        }

        // Checking an object that returned by Service and Exptected is equal.
        [Test]
        public void GetEmpByIDTest()
        {
            int id = 1;
            var e = empService.GetEmp(id);
            var exptectedObj = Emps4TestCases.Where(w => w.id == id).FirstOrDefault();

            string expectedJson = JsonSerializer.Serialize(exptectedObj);
            string actualJson = JsonSerializer.Serialize(e);
            Assert.AreEqual(expectedJson, actualJson);
        }

        // Below test run multiple times provided by TestCaseAttribute values
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        //[TestCase(1, 2, 3)] // If we have more parameters in Method's signature
        public void GetEmpByIDTestByTheory(int id)
        {
            var e = empService.GetEmp(id);
            var exptectedObj = Emps4TestCases.Where(w => w.id == id).FirstOrDefault();

            Assert.AreEqual(exptectedObj.id, e.id);
        }

        // Must return Null value
        [Test]
        public void GetEmpByIDTestForNull()
        {
            int id = 100;
            var e = empService.GetEmp(id);
            Assert.Null(e);
        }

        // Check for Not Null Value
        [Test]
        public void GetEmpByIDTestForNotNull()
        {
            int id = 1;
            var e = empService.GetEmp(id);
            Assert.NotNull(e);
        }


        // Apply a condition or constraints to actual values
        [Test]
        public async Task PostEmpTest()
        {
            int ExpectedEmpID = Emps4TestCases.Max(m => m.id) + 1;
            var e = new Emp { id = 0, name = "Name4", age = 50, salary = 4000 };
            var eID = await empService.PostEmp(e);
            Assert.That(eID, Is.EqualTo(ExpectedEmpID)); // OR below line
            // Assert.AreEqual(ExpectedEmpID, eID);
        }

    }
}
