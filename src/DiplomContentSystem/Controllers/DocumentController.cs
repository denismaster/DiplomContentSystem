using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Services.Departments;
using DiplomContentSystem.Requests;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using DiplomContentSystem.Services.CalendarEvents;

namespace DiplomContentSystem.Controllers
{
    [Route("api/documents")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class DocumentsController : Controller
    {
        private readonly RequestService _service;
        private readonly CalendarEventService _calendarService;
        public DocumentsController(RequestService service,CalendarEventService calendarService)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (calendarService == null) throw new ArgumentNullException(nameof(_calendarService));
            _service = service;
            _calendarService = calendarService;
        }
        [HttpPost("calendar/{id:int}")]
        public async Task<IActionResult> DownloadStages(int id)
        {
            var data = _calendarService.GetTemplateData(id);
            var stream = await _service.SendRequest(data);
            return new FileStreamResult(stream,"application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }
    }
}