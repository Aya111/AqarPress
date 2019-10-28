using DB_A4D6F8_AqarPress.Data;
using DB_A4D6F8_AqarPress.Data.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarPress.Core
{
   public class Prefetch
    {
        public interface IPrefetch
        {
            SD.LLBLGen.Pro.ORMSupportClasses.IPrefetchPath2 Get();
        }


        public class ProjectDiscussionPrefetch : IPrefetch
        {

            public SD.LLBLGen.Pro.ORMSupportClasses.IPrefetchPath2 Get()
            {
                SD.LLBLGen.Pro.ORMSupportClasses.IPrefetchPath2 path = new SD.LLBLGen.Pro.ORMSupportClasses.PrefetchPath2((int)EntityType.ProjectDiscussionEntity);

                path.Add(ProjectDiscussionEntity.PrefetchPathUser);

                return path;
            }
        }
    }
}
