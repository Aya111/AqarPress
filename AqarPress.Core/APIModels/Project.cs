using AqarPress.Data.EntityClasses;
using System;

namespace AqarPress.Core.APIModels
{
    public class Project
    {
        public Project(ProjectEntity entity, Func<(int projectId, string path), string> imagerPath)
        {
            Id = entity.Id;
            Name = entity.Name;
            DeveloperId = entity.DeveloperId;
            DateCreated = entity.DateCreated;
            ArabicName = entity.ArabicName;
            CategoryId = entity.CategoryId;
            Path = imagerPath((entity.Id, entity.Path));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DeveloperId { get; set; }
        public DateTime DateCreated { get; set; }
        public string ArabicName { get;  set; }
        public int CategoryId { get; set; }

        public string Path { get; set; }
    }
}