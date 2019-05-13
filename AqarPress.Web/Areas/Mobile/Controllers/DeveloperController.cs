using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.ORMSupportClasses;
using AqarPress.Web.Attributes;

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
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            var result = await _developerRepository.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            var reply = result.Select(r => new Developer
            {
                Id = r.Id,
                Name = r.Name,
                Path = r.Path
            });

            return Ok(reply);
        }
    }
}