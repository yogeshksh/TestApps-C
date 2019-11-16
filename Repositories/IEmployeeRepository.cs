
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}