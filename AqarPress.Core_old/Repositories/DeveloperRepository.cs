using AqarPress.Data.DatabaseSpecific;
using AqarPress.Data.EntityClasses;
using AqarPress.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace AqarPress.Core.Repositories
{
    public class DeveloperRepository : ICreateInScope
    {
        public async Task<List<DeveloperEntity>> GetAll()
        {
            using (var adapter = Adapter.Create())
            {
                var meta = new LinqMetaData(adapter);

                var query = await meta.Developer.Where(p => p.IsActive).ToListAsync();

                return query;
            }
        }
    }
}