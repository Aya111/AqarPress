using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imager = AqarPress.Web.Areas.Mobile.Controllers.MediaController;


namespace AqarPress.web.Mobile.Controllers
{
    [Route("api/1/Developer")]
    [ApiController]
    [TypeFilter(typeof(RequireAPISession))]
    public class DeveloperController : ControllerBase
    {
        public DeveloperRepository _developerRepository;

        public DeveloperController(DeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Developer>>> GetAll()
        {
            var result = await _developerRepository.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            var reply = result.Select(r => new Developer(r, t => Imager.GenerateDeveloperImageUrl(Request, r.Path)));

            return Ok(reply);
        }
    }
}