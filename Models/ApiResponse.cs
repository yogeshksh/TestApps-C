using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public Employee Employee { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
