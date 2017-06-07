using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Services.Users;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using Newtonsoft.Json;
namespace DiplomContentSystem.Controllers
{   
    [Route("api/[controller]")]
    [Authorize(Policy=AuthConsts.PolicyUser)]
    public class UsersController : Controller
    {
        private readonly UserService _service;
        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public IActionResult Get([FromBody] Dto.UserRequest request )
        {
            return Ok(_service.GetUsers(request));
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
        public IActionResult Add([FromBody]Dto.UserEditItem User)
        {
            return Ok(_service.AddUser(User));
        }
         [HttpPost("update")]
        public IActionResult Update([FromBody]Dto.UserEditItem User)
        {
            return Ok(_service.UpdateUser(User));
        }
    }
}
