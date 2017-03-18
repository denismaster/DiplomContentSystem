using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomContentSystem.Services.Teachers;
using DiplomContentSystem.Core;
using Newtonsoft.Json;
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

        [HttpPost("")]
        public IActionResult Get([FromBody] Dto.TeacherRequest request )
        {
            return Ok(_service.GetTeachers(request));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            var result = _service.Get(id);
            if(result!=null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Teacher teacher)
        {
            return Ok(_service.AddTeacher(teacher));
        }
         [HttpPost("update")]
        public IActionResult Update([FromBody] Teacher teacher)
        {
            return Ok(_service.UpdateTeacher(teacher));
        }
    }
}
