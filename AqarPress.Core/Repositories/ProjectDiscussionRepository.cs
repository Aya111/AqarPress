using AqarPress.Core.APIModels;
using AqarPress.Data.EntityClasses;
using AqarPress.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AqarPress.Core.Repositories
{
    public class ProjectDiscussionRepository : ICreateInScope
    {
        public async Task<List<ProjectDiscussionEntity>> GetProjectDiscussion(int projectId)
        {
            using (var adapter = Adapter.Create())
            {
                var meta = new LinqMetaData(adapter);

                var query = await meta.ProjectDiscussion.Where(d => d.ProjectId == projectId).ToListAsync();

                return query;
            }
        }

        public async Task<Result<ProjectComment>> AddComment(ProjectComment comment)
        {
            try
            {
                using (var adapter = Adapter.Create())
                {
                    var commentEntity = new ProjectDiscussionEntity
                    {
                        MessageBody = comment.MessageBody,
                        CommenterId = comment.CommenterId,
                        ProjectId = comment.ProjectId
                    };

                    var result = await adapter.SaveEntityAsync(commentEntity, true);

                    return Result<ProjectComment>.True(comment);
                }
            }
            catch (Exception ex)
            {
                return Result<ProjectComment>.False(ex);
            }
        }
    }
}