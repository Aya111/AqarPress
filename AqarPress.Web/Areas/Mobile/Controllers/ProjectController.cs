using AqarPress.Core;
using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using AqarPress.View.DtoClasses;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imager = AqarPress.Web.Areas.Mobile.Controllers.MediaController;

namespace AqarPress.web.Areas.Mobile.Controllers
{
    [Produces("application/json")]
    [Route("api/1/Project")]
    [ApiController]
    [TypeFilter(typeof(RequireAPISession))]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _projectRepository;
        private readonly IdentityService _identityService;

        public ProjectController(ProjectRepository projectRepository, IdentityService identityService)
        {
            _projectRepository = projectRepository;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetDeveloperProjects(int developerId)
        {
            if (developerId == 0)
            {
                return BadRequest();
            }

            var result = await _projectRepository.GetDeveloperProjects(developerId);

            if (result == null)
            {
                return NotFound();
            }

            var reply = result.Select(r => new Project(r, t => Imager.GenerateProjectImageUrl(Request, r.Path)));

            return Ok(reply);
        }
    }
}