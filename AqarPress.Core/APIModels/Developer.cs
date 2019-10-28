using DB_A4D6F8_AqarPress.Data.EntityClasses;
using System;

namespace AqarPress.Core.APIModels
{
    public class Developer
    {
        public Developer(DeveloperEntity entity, Func<(int developerId, string path), string> imagerPath)
        {
            Id = entity.Id;
            Name = entity.Name;
            Path = imagerPath((entity.Id, entity.Path));
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }
    }
}