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
    public class Reply
    {
        //Foreign Key to Comment via Id w/ virtual Comment
        
        [ForeignKey(nameof(comment)]
        [Required]
        public int ReplyId { get; set; }
        //string text
        [Required]
        public string Content { get; set; }
        //Virtual thing which overrides stuff
        public virtual Users User { get; set; }
        //Guid Author
        public Guid AuthorId { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
