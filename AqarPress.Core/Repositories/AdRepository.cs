using DB_A4D6F8_AqarPress.Data.EntityClasses;
using DB_A4D6F8_AqarPress.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarPress.Core.Repositories
{
    public class AdRepository : ICreateInScope
    {
        public async Task<List<AdEntity>> GetAll()
        {
            using (var adapter = Adapter.Create())
            {
                var meta = new LinqMetaData(adapter);

                var query = await meta.Ad.ToListAsync();

                return query;
            }
        }
    }
}
