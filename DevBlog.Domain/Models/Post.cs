using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Domain.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(1000)]
        public string Body { get; set; }
        // Rating: On each star rate, calculate average in service
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        // Many-to-Many relation Tags - Posts
        public virtual List<Tag> Tags { get; set; }
        // One-to-Many relation User - Posts
        public int UserId { get; set; }
        public virtual User User { get; set; }
        // One-to-Many relation Post - Comments
        public virtual List<Comment> Comments { get; set; }
        // One-to-Many relation Post - Stars
        public virtual List<Star> Stars { get; set; }
    }
}
