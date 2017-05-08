using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Services.Groups;
namespace DiplomContentSystem.Controllers
{
    [Route("api/groups")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class GroupController : Controller
    {
        private readonly GroupService _service;
        public GroupController(GroupService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _service = service;
        }

        public IActionResult Get([FromBody] Dto.GroupRequest request)
        {
            return Ok(_service.GetGroups(request));
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
        public IActionResult Add([FromBody]Dto.GroupEditItem group)
        {
            return Ok(_service.Add(group));
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody]Dto.GroupEditItem group)
        {
            return Ok(_service.Update(group));
        }
    }
}