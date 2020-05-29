using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarPress.Core.APIModels
{
   public class CommentAttachment
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public string Comment { get; set; }
    }
}
