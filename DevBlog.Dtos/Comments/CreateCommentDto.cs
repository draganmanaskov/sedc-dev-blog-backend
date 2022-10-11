using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Dtos.Comments
{
    public class CreateCommentDto
    {
        public string Body { get; set; }
        public bool Anonymous { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
