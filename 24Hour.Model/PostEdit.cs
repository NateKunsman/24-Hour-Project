using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Model
{
    public class PostEdit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual string Content { get; set; }
    }
}
