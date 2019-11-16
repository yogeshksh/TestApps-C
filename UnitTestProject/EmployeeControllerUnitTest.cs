using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using TestApplication.Controllers;
using TestApplication.Models;
using TestApplication.Repositories;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeeControllerUnitTest
    {
        [TestMethod]
        public void TestGetReturnsAllEmployees()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var mockConfig = new Mock<IConfiguration>();
            var mockMapper = new Mock<AutoMapper.IMapper>();
            var mockLogger = new Mock<ILoggerFactory>();
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee {FirstName ="TestFirst1", LastName ="TestLast1", HireDate = DateTime.Now });
            employeeList.Add(new Employee { FirstName = "TestFirst2", LastName = "TestLast2", HireDate = DateTime.Now });
          
            mockRepository.Setup(x => x.GetAllEmployees())
                .Returns(employeeList);
            // mockCache.Setup(c => c.CreateEntry("EmployeesListingKey")).Returns(employeeList) ;
            var mockCache = MockMemoryCacheService.GetMemoryCache(employeeList);    //new Mock<Microsoft.Extensions.Caching.Memory.IMemoryCache>();

            var controller = new EmployeesController(mockConfig.Object, mockRepository.Object, mockMapper.Object, mockLogger.Object, mockCache);

            // Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<Employee>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Count);
        }

        [TestMethod]
        public void TestGetReturnsAllEmployeesByLastName()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var mockConfig = new Mock<IConfiguration>();
            var mockMapper = new Mock<AutoMapper.IMapper>();
            var mockLogger = new Mock<ILoggerFactory>();
            var mockCache = new Mock<Microsoft.Extensions.Caching.Memory.IMemoryCache>();
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee { FirstName = "TestFirst1", LastName = "TestLast1", HireDate = DateTime.Now });
            employeeList.Add(new Employee { FirstName = "TestFirst2", LastName = "TestLast2", HireDate = DateTime.Now });

            mockRepository.Setup(x => x.GetAllEmployees())
                .Returns(employeeList);

            var controller = new EmployeesController(mockConfig.Object, mockRepository.Object, mockMapper.Object, mockLogger.Object, mockCache.Object);

            // Act
            var actionResult = controller.Get("TestLast2");
            var contentResult = actionResult as OkNegotiatedContentResult<List<Employee>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count);
        }

        [TestMethod]
        public void TestGetReturnsNoEmployee()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var mockConfig = new Mock<IConfiguration>();
            var mockMapper = new Mock<AutoMapper.IMapper>();
            var mockLogger = new Mock<ILoggerFactory>();
            var mockCache = new Mock<Microsoft.Extensions.Caching.Memory.IMemoryCache>();
            List<Employee> employeeList = new List<Employee>();
            mockRepository.Setup(x => x.GetAllEmployees())
                .Returns(employeeList);

            var controller = new EmployeesController(mockConfig.Object, mockRepository.Object, mockMapper.Object, mockLogger.Object, mockCache.Object);

            // Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<Employee>>;

            // Assert
            Assert.IsNull(contentResult);
            Assert.IsNull(contentResult.Content);
            Assert.AreEqual(0, contentResult.Content.Count);
        }

    }
}
