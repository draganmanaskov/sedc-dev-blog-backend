using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        // One-to-Many relation User - Posts
        public virtual IList<Post> Posts { get; set; }
        // One-to-Many relation User - Comments
        public virtual IList<Comment> Comments { get; set; }
        // One-to-Many relation User - Stars
        public virtual IList<Star> Stars { get; set; }
    }
}
