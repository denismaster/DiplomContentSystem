using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Controllers
{
    [Route("api/groups")]
    [Authorize(Policy=AuthConsts.PolicyUser)]
    public class GroupController : Controller
    {
        private readonly IRepository<Group> _repository;
        public GroupController(IRepository<Group> repository)
        {
            if(repository==null) throw new ArgumentNullException(nameof(repository));
            _repository = repository;
        }

        [HttpGet("select-list")]
        public IActionResult Get()
        {
            var result = _repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
            if(result!=null) return Ok(result);
            return BadRequest();
        }
    }
}