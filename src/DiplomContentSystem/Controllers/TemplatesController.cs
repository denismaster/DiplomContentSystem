using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DiplomContentSystem.Controllers
{
    [Route("api/templates")]
    [Authorize(Policy=AuthConsts.PolicyUser)]
    public class TemplateController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public TemplateController(IHostingEnvironment environment)
        {
            if(environment==null) throw new ArgumentNullException(nameof(environment));
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormCollection form)
        {
            try
            {
                var files = form.Files;
                var uploads = Path.Combine(_environment.WebRootPath,"..","..","..", "templates");
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
