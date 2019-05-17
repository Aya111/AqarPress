using AqarPress.Core;
using AqarPress.Core.APIModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AqarPress.Web.Areas.Mobile.Controllers
{
    public class MediaController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        private const string IMAGE_CONTENT_TYPE = "image/jpg";
        private const string NO_LOGO_PLACEHOLDER = "/images/no_logo.png";

        public MediaController(IHostingEnvironment env)
        {
            _env = env;
        }
        public static string GenerateDeveloperImageUrl(HttpRequest request, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return $"{request.Scheme}://{request.Host}/{NO_LOGO_PLACEHOLDER}";
            else
                return $"{request.Scheme}://{request.Host}/{nameof(Developer)}/{fileName}";
        }

        public static string GenerateProjectImageUrl(HttpRequest request, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return $"{request.Scheme}://{request.Host}/{NO_LOGO_PLACEHOLDER}";
            else
                return $"{request.Scheme}://{request.Host}/{nameof(Project)}/{fileName}";
        }

        [Route(nameof(Developer) + "/{name}")]
        public IActionResult Workshop(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest();

            var path = Config.GenerateDeveloperLogoPath(_env, name);

            if (System.IO.File.Exists(path) == false)
                return NotFound();

            var fileContents = System.IO.File.ReadAllBytes(path);
            return File(fileContents, IMAGE_CONTENT_TYPE);
        }

        [Route(nameof(Project) + "/{name}")]
        public IActionResult Project(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest();

            var path = Config.GenerateProjectLogoPath(_env, name);

            if (System.IO.File.Exists(path) == false)
                return NotFound();

            var fileContents = System.IO.File.ReadAllBytes(path);
            return File(fileContents, IMAGE_CONTENT_TYPE);
        }
    }
}
