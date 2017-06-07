using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Services.Departments;

namespace DiplomContentSystem.Controllers
{
    [Route("api/departments")]
    [Authorize(Policy=AuthConsts.PolicyUser)]
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _service;
        public DepartmentController(DepartmentService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _service = service;
        }
        public IActionResult Get([FromBody] Dto.DepartmentRequest request)
        {
            return Ok(_service.GetDepartments(request));
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
        public IActionResult Add([FromBody]Dto.DepartmentEditItem department)
        {
            return Ok(_service.Add(department));
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody]Dto.DepartmentEditItem department)
        {
            return Ok(_service.Update(department));
        }

        [HttpGet("select-list")]
        public IActionResult Get()
        {
            var result = _service.GetAsSelectList();
            if (result != null) return Ok(result);
            return BadRequest();
        }
    }
}