using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    class ReplyDetail
    {
        public int ReplyId { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
