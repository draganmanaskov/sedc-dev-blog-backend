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
        public DateTime CreatedAt { get; set; }
        // One-to-Many relation User - Posts
        public virtual List<Post> Posts { get; set; }
        // One-to-Many relation User - Comments
        public virtual List<Comment> Comments { get; set; }
        // One-to-Many relation User - Stars
        public virtual List<Star> Stars { get; set; }
    }
}
