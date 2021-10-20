using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private readonly Guid userId;
        public Comment(Guid userId)
       // { _userId = userId; }

        public virtual List<Reply> Reply { get; set; }  = new List<Reply>();

        [ForeignKey(nameof(PostId))]
        public int PostId { get; set; }


    }
}
