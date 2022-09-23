using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Shared.CustomExceptions
{
    public class TagDataException : Exception
    {
        public TagDataException(string message) : base(message)
        {

        }
    }
}
