using AqarPress.Core;
using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using AqarPress.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imager = AqarPress.Web.Areas.Mobile.Controllers.MediaController;

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
        private readonly IHostingEnvironment _environment;


        public ProjectDiscussionController(ProjectDiscussionRepository projectDiscussionRepository, IdentityService identityService, IHostingEnvironment environment)
        {
            _projectDiscussionRepository = projectDiscussionRepository;
            _identityService = identityService;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
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
                CommenterName = d.User.Name,
                CommenterMobile = d.User.MobilePhone,
                attachments = d.Attachments?.Select(a => Imager.GenerateDiscussionAttachmentImageUrl(Request, a.Path, d.Id)).ToList()
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

        [HttpPost, Route("AddFile")]
        public async Task<ActionResult<ProjectDiscussionAttachment>> AddFile(IFormFile file, int projectDiscussionId)
        {
            try
            {
                var discussionAttachmentsFolder = string.Concat(_environment.WebRootPath, Config.DISCUSSION_ATTACHMENT_IMAGE_PATH, projectDiscussionId.ToString());
                if (!Directory.Exists(discussionAttachmentsFolder))
                    Directory.CreateDirectory(discussionAttachmentsFolder);

                if (file.Length > 0)
                {
                    var path = Config.GenerateDiscussionAttachmentImagePath(_environment, file.FileName, projectDiscussionId);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            var result = await _projectDiscussionRepository.AddAttachment(projectDiscussionId, file.FileName);

            if (result.IsFalse)
            {
                return StatusCode(500, result.ExceptionObject);
            }

            return Ok(result.Value);
        }
    }
}