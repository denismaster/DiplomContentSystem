using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Services.DiplomWorks;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using Newtonsoft.Json;
namespace DiplomContentSystem.Controllers
{
    [Route("api/diploms")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class DiplomWorksController : Controller
    {
        private readonly DiplomWorksService _service;
        public DiplomWorksController(DiplomWorksService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public IActionResult Get([FromBody] Dto.DiplomWorkRequest request)
        {
            return Ok(_service.GetDiplomWorks(request));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            var result = _service.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] DiplomWork DiplomWork)
        {
            return Ok(_service.AddDiplomWork(DiplomWork));
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] DiplomWork DiplomWork)
        {
            return Ok(_service.UpdateDiplomWork(DiplomWork));
        }
    }
}
