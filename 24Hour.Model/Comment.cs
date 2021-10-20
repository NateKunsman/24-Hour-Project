using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        public virtual List<Reply> Reply { get; set; }  = new List<Reply>();

        [ForeignKey(nameof(PostId))]
        public int PostId { get; set; }
    }
}
