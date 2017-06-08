using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Services.DiplomWorks;
namespace DiplomContentSystem.Controllers
{
    [Route("api/charts")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class ChartController : Controller
    {
        private readonly DiplomWorksService _service;
        public ChartController(DiplomWorksService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _service = service;
        }

        [HttpGet("diplom")]
        public IActionResult Get()
        {
            var diploms = _service.GetChartData();
            return Ok(new {Data = diploms});
        }

    }
}