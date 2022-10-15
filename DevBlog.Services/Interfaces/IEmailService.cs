using DevBlog.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Interfaces
{
    public interface IEmailService
    {
        void Subscribe(string emailAddress);
        void Unsubscribe(string emailAddress);
        void SendEmail(string postTitle, int postId); 
    }
}
