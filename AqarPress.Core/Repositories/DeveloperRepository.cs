using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.ORMSupportClasses;
using DB_A4D6F8_AqarPress.Data.EntityClasses;
using DB_A4D6F8_AqarPress.Data.Linq;

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