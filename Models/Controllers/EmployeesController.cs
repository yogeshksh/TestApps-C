using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using TestApplication.Models;
using TestApplication.Repositories;
using TestApplication.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace TestApplication.Controllers
{
    /// <summary>
    /// Employee APIs to return employee related information
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private ILogger _logger;
        private readonly IMemoryCache _cache;
        private const string EmployeesCacheKey= "EmployeesListingKey";
        private double _absoluteExpiration =30;
        private double _slidingExpiration = 30;
        
        /// <summary>
        ///  
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="loggerFactory"></param>
        public EmployeesController(IConfiguration configuration, IEmployeeRepository employeeRepository, IMapper mapper, ILoggerFactory loggerFactory, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger(nameof(EmployeesController));
            _cache = memoryCache;

        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        // GET api/Employee
        [NoCache]
        [ProducesResponseType(typeof(IEnumerable<EmployeeViewModel>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<EmployeeViewModel>>(GetAllEmployees()));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet("{lastname}")]
        // GET api/Employee/Test
        [NoCache]
        [ProducesResponseType(typeof(IEnumerable<EmployeeViewModel>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public IActionResult Get(string lastname)
        {
            try
            {
                var data = _mapper.Map<IEnumerable<EmployeeViewModel>>(GetAllEmployees().Where(e => e.LastName == lastname));
                return Ok(data);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        /// <summary>
        /// return the employees from the cache memory, if not available in the cache then call repository method to populate cache and return data
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Employee> GetAllEmployees()
        {
            //check if object exist in the cache and if not then call repository to populate cache
            if (!_cache.TryGetValue(EmployeesCacheKey, out IEnumerable<Employee> employees))
            {
                //retrieve data from the repository as it is not in the cache
                employees = _employeeRepository.GetAllEmployees();
                //set cache expiry
                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_absoluteExpiration), 
                    SlidingExpiration = TimeSpan.FromMinutes(_slidingExpiration) 
                };
                //set callback 
                options.RegisterPostEvictionCallback(Callback, "Any information related to state or whatever is required");
                //populate cache
                _cache.Set(EmployeesCacheKey, employees, options);
            }
            return employees;
        }

        /// <summary>
        /// callback method when changes occurs to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        /// <param name="state"></param>
        private void Callback(object key, object value, EvictionReason reason, object state)
        {
           
        }
    }
}
