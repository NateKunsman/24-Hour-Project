using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    public class Reply
    {
        //Foreign Key to Comment via Id w/ virtual Comment
        
        [ForeignKey(nameof(Reply))]
        public int ReplyId { get; set; }
        //string text
        public string Content { get; set; }
        //Guid Author
        public Guid AuthorId { get; set; }
    }
}
