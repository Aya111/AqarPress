using AqarPress.Core;
using AqarPress.Core.Repositories;
using AqarPress.View.DtoClasses;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<ProjectView>>> GetDeveloperProjects(int developerId)
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

            var reply = result.Select(p => new ProjectView
            {
                Id = p.Id,
                Name = p.Name,
                DeveloperId = p.DeveloperId,
                DateCreated = p.DateCreated,
                //ArabicName = p.ArabicName,
                CategoryId = p.CategoryId,
                Path = p.Path
            });

            return Ok(reply);
        }
    }
}