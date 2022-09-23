﻿using System;
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
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        // Rating: On each star rate, calculate average in service
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        // Many-to-Many relation Tags - Posts
        public virtual IList<Tag> Tags { get; set; }
        // One-to-Many relation User - Posts
        public int UserId { get; set; }
        public User User { get; set; }
        // One-to-Many relation Post - Comments
        public virtual IList<Comment> Comments { get; set; }
        // One-to-Many relation Post - Stars
        public virtual IList<Star> Stars { get; set; }
    }
}