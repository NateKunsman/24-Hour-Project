using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    public class PostList
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public virtual string Content { get; set; }
        public Guid AuthorId { get; set; }
    }
}
