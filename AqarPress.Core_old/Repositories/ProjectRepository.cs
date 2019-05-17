using AqarPress.Core.APIModels;
using AqarPress.Data.EntityClasses;
using AqarPress.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AqarPress.Core.Repositories
{
    public class ProjectRepository : ICreateInScope
    {
        public async Task<List<ProjectDiscussionEntity>> GetProjectDiscussion(int projectId)
        {
            using (var adapter = Adapter.Create())
            {
                var meta = new LinqMetaData(adapter);

                var query = await meta.ProjectDiscussion.Where(p => p.ProjectId == projectId).ToListAsync();

                return query;
            }
        }

        public async Task<List<ProjectEntity>> GetDeveloperProjects(int developerId)
        {
            using (var adapter = Adapter.Create())
            {
                var meta = new LinqMetaData(adapter);

                var query = await meta.Project.Where(p => p.DeveloperId == developerId).ToListAsync();

                return query;
            }
        }
        public async Task<ProjectEntity> Create(Project projectModel, int sellerId)
        {
            try
            {
                using (var adapter = Adapter.Create())
                {
                    var propertyEntity = new ProjectEntity
                    {
                        DeveloperId = projectModel.DeveloperId,
                        Name = projectModel.Name
                    };

                    await adapter.SaveEntityAsync(propertyEntity, true);

                    return propertyEntity;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return null;
            }
        }
    }
}