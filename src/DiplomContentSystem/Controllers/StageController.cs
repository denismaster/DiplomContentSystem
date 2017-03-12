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
    public class StagesController : Controller
    {
        private readonly StageService _service;
        public StagesController(StageService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public IActionResult Get([FromBody] Dto.StageRequest request)
        {
            return Ok(_service.GetStages(request));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Stage stage)
        {
            return Ok(_service.AddStage(stage));
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] Stage stage)
        {
            return Ok(_service.UpdateStage(stage));
        }
    }
}
