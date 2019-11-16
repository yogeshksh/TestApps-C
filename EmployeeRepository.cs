using System.Collections.Generic;
using System;
using TestApplication.Models;

namespace TestApplication.Repositories
{
    /// <summary>
    /// Employe repository class to provide employee related information
    /// currently it initializes with hard coded data and cached into memory and returned this from memory
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private  IList<Employee> _employees;

        /// <summary>
        /// populate initial employee data - hard coded values
        /// </summary>
        private void InitializeData()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "TestFirst1",
                    LastName ="TestLast1",
                    HireDate = DateTime.UtcNow.AddDays(-100)
                },
                new Employee
                {
                    FirstName = "TestFirst2",
                    LastName ="TestLast2",
                    HireDate = DateTime.UtcNow.AddDays(-50)
                },
                new Employee
                {
                    FirstName = "TestFirst3",
                    LastName ="TestLast3",
                    HireDate = DateTime.UtcNow.AddDays(-30)
                },
                new Employee
                {
                    FirstName = "TestFirst4",
                    LastName ="TestLast4",
                    HireDate = DateTime.UtcNow.AddDays(-20)
                },
                new Employee
                {
                    FirstName = "TestFirst5",
                    LastName ="TestLast5",
                    HireDate = DateTime.UtcNow.AddDays(-10)
                }
            };
        }

        public EmployeeRepository()
        {
           InitializeData();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }      
    }
}