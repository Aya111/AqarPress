using System;
using System.Collections.Generic;

namespace AqarPress.Core.APIModels
{
    public class ProjectComment
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }

        public int CommenterId { get; set; }

        public string CommenterName { get; set; }

        public string CommenterMobile { get; set; }

        public int ProjectId { get; set; }

        public DateTime DateCreated { get; set; }

        public List<string> attachments { get; set; }
    }
}