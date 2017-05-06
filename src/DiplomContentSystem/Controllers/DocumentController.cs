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

namespace DiplomContentSystem.Controllers
{
    [Route("api/documents")]
    [Authorize(Policy = AuthConsts.PolicyUser)]
    public class DocumentsController : Controller
    {
        private readonly RequestService _service;
        public DocumentsController(RequestService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _service = service;
        }
        [HttpPost("calendar/{id:int}")]
        public async Task<IActionResult> DownloadStages(int id)
        {
            var stream = await _service.SendRequest(true);
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            result.FileDownloadName = "calendar.docx";
            return result;
           // return File(stream,"application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            //return new FileStreamResult(stream, new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
           // {
          //      FileDownloadName = "calendar.docx"
          //  };
        }

    }
}