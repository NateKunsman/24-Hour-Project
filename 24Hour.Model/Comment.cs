using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<Reply> Reply { get; set; }  = new List<Reply>();

        [ForeignKey(nameof(User))]
        public int PostId { get; set; }
        public virtual Users User { get; set;}

    }
}
