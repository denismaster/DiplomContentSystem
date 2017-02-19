using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomContentSystem.Services;
using DiplomContentSystem.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomContentSystem.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _service;
        public StudentController(StudentService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet("")]
        public async Task<IActionResult> Students()
        {
            return Ok(_service.GetStudents());
        }
    }
}
