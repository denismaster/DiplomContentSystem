using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Services.Specialities;
namespace DiplomContentSystem.Controllers
{
    [Route("api/specialities")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class SpecialityController : Controller
    {
        private readonly SpecialityService _service;
        public SpecialityController(SpecialityService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _service = service;
        }

        public IActionResult Get([FromBody] Dto.SpecialityRequest request)
        {
            return Ok(_service.GetSpecialitys(request));
        }

        [HttpGet("select-list")]
        public IActionResult Get()
        {
            var result = _service.GetAsSelectList();
            if (result != null) return Ok(result);
            return BadRequest();
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
        public IActionResult Add([FromBody]Dto.SpecialityEditItem group)
        {
            return Ok(_service.Add(group));
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody]Dto.SpecialityEditItem group)
        {
            return Ok(_service.Update(group));
        }
    }
}