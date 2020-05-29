using AqarPress.Core.APIModels;
using AqarPress.Core.Identity;
using DB_A4D6F8_AqarPress.Data.EntityClasses;
using DB_A4D6F8_AqarPress.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AqarPress.Core.Prefetch;

namespace AqarPress.Core.Repositories
{
    public class ProjectDiscussionRepository : ICreateInScope
    {
        public async Task<List<ProjectDiscussionEntity>> GetProjectDiscussion(int projectId)
        {
            using (var adapter = Adapter.Create())
            {
                var meta = new LinqMetaData(adapter);

                var query = await meta.ProjectDiscussion.Where(d => d.ProjectId == projectId).WithPath(new ProjectDiscussionPrefetch().Get()).ToListAsync();

                return query;
            }
        }

        public async Task<Result<ProjectComment>> AddComment(ProjectComment comment, APISession session)
        {
            try
            {
                using (var adapter = Adapter.Create())
                {
                    var commentEntity = new ProjectDiscussionEntity
                    {
                        MessageBody = comment.MessageBody,
                        CommenterId = session.UserId,
                        ProjectId = comment.ProjectId
                    };

                    var result = await adapter.SaveEntityAsync(commentEntity, true);

                    var meta = new LinqMetaData(adapter);

                    comment.CommenterName = session.User.Name;

                    comment.CommenterMobile = session.User.MobilePhone;

                    return Result<ProjectComment>.True(comment);
                }
            }
            catch (Exception ex)
            {
                return Result<ProjectComment>.False(ex);
            }
        }

        public async Task<Result<ProjectDiscussionAttachment>> AddAttachment(int projectDiscussionId, string path)
        {
            try
            {
                using (var adapter = Adapter.Create())
                {
                    var attachmentEntity = new AttachmentEntity
                    {
                        Path = path,
                        ProjectDiscussionId = projectDiscussionId

                    };

                    var result = await adapter.SaveEntityAsync(attachmentEntity, true);

                    var meta = new LinqMetaData(adapter);

                    var attachmentModel = new ProjectDiscussionAttachment();
                    attachmentModel.AttachmentId = attachmentEntity.Id;
                    attachmentModel.ProjectDiscussionId = projectDiscussionId;

                    return Result<ProjectDiscussionAttachment>.True(attachmentModel);
                }
            }
            catch (Exception ex)
            {
                return Result<ProjectDiscussionAttachment>.False(ex);
            }
        }
    }
}