using System;

namespace AqarPress.Core.APIModels
{
    public class ProjectComment
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }

        public int CommenterId { get; set; }

        public string CommenterName { get; set; }

        public int ProjectId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}