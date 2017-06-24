using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using DiplomContentSystem.Authentication;
using DiplomContentSystem.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
namespace DiplomContentSystem.Controllers
{   
    [Route("api/[controller]")]
    [Authorize(Policy=AuthConsts.PolicyUser)]
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            if(environment==null) throw new ArgumentNullException(nameof(environment));
            _environment = environment;
        }

        [HttpPost("template")]
        public async Task<IActionResult> UploadTemplate(IFormCollection form)
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
        [HttpPost("attachment")]
        public async Task<IActionResult> UploadAttachment(IFormCollection form)
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
