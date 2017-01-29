using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomContentSystem.Services;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private readonly TeacherService _service;
        public TeachersController(TeacherService service)
        {
            _service = service;
        }
        [HttpGet("")]
        public IActionResult Teachers()
        {
            return Ok(_service.GetTeachers());
        }
    }
}
