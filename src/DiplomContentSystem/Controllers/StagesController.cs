using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Services.CalendarEvents;
namespace DiplomContentSystem.Controllers
{
    [Route("api/calendar")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class StagesController : Controller
    {
        private readonly CalendarEventService _service;
        public StagesController( CalendarEventService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetCalendarEvents(id));
        }
    }
}