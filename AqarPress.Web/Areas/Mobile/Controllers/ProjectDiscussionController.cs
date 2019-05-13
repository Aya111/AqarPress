using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using AqarPress.Edit.DtoClasses;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AqarPress.web.Areas.Mobile.Controllers
{
    [Produces("application/json")]
    [Route("api/1/Duscussion")]
    [ApiController]
    [TypeFilter(typeof(RequireAPISession))]
    public class ProjectDiscussionController : ControllerBase
    {
        private readonly ProjectDiscussionRepository _projectDiscussionRepository;

        public ProjectDiscussionController(ProjectDiscussionRepository projectDiscussionRepository)
        {
            _projectDiscussionRepository = projectDiscussionRepository;
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
                DateCreated = d.DateCreated
            });

            return Ok(reply);
        }

        [HttpPost, Route("AddComment")]
        public async Task<ActionResult<ProjectComment>> AddComment(ProjectComment comment)
        {
            var result = await _projectDiscussionRepository.AddComment(comment);

            if (result.IsFalse)
            {
                return StatusCode(500, result.ExceptionObject);
            }

            return Ok(result.Value);
        }
    }
}