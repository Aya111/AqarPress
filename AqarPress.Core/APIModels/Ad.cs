using DB_A4D6F8_AqarPress.Data.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarPress.Core.APIModels
{
    public class Ad
    {
        public Ad(AdEntity entity, Func<string, string> imagerPath)
        {
            Id = entity.Id;
            Name = entity.Name;
            Path = imagerPath(entity.Path);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }
        public string RedirectPath { get; set; }
    }
}
