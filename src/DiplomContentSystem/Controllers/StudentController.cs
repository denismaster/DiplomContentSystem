using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Services.Students;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomContentSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class StudentsController : Controller
    {
        private readonly StudentService _service;
        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public IActionResult Get([FromBody]Dto.StudentRequest request)
        {
            return Ok(_service.GetStudents(request));
        }
    }
}
