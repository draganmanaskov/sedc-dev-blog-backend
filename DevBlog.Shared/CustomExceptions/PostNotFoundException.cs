using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Shared.CustomExceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(string message) : base(message)
        {

        }
    }
}
