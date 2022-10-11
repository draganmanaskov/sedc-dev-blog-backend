using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Domain.Models
{
    public class Star
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value { get; set; }
        // One-to-Many relation User - Stars
        public int UserId { get; set; }
        public virtual User User { get; set; }
        // One-to-Many relation Post - Stars
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
