using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Controllers
{
    [Route("api/specialities")]
    [Authorize(Policy=AuthConsts.PolicyUser)]
    public class SpecialityController : Controller
    {
        private readonly IRepository<Speciality> _repository;
        public SpecialityController(IRepository<Speciality> repository)
        {
            if(repository==null) throw new ArgumentNullException(nameof(repository));
            _repository = repository;
        }

        [HttpGet("")]
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
