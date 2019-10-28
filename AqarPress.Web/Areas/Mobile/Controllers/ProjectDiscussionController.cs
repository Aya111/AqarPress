using AqarPress.Core;
using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AqarPress.web.Areas.Mobile.Controllers
{
    [Produces("application/json")]
    [Route("api/1/ProjectDiscussion")]
    [ApiController]
    [TypeFilter(typeof(RequireAPISession))]
    public class ProjectDiscussionController : ControllerBase
    {
        private readonly ProjectDiscussionRepository _projectDiscussionRepository;
        private readonly IdentityService _identityService;

        public ProjectDiscussionController(ProjectDiscussionRepository projectDiscussionRepository, IdentityService identityService)
        {
            _projectDiscussionRepository = projectDiscussionRepository;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectComment>>> Get(int projectId)
        {
            var result = await _projectDiscussionRepository.GetProjectDiscussion(projectId);

            if (result == null)
            {
                return NotFound();
            }

            var reply = result.Select(d => new ProjectComment
            {
                Id = d.Id,
                MessageBody = d.MessageBody,
                CommenterId = d.CommenterId,
                ProjectId = d.ProjectId,
                DateCreated = d.DateCreated,
                CommenterName = d.User.Name
            });

            return Ok(reply);
        }

        [HttpPost, Route("AddComment")]
        public async Task<ActionResult<ProjectComment>> AddComment(ProjectComment comment)
        {
            var session = _identityService.GetUserSessionInfo(Request.HttpContext);

            var result = await _projectDiscussionRepository.AddComment(comment, session);

            if (result.IsFalse)
            {
                return StatusCode(500, result.ExceptionObject);
            }

            return Ok(result.Value);
        }
    }
}