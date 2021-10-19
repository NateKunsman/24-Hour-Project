using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Users
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AutherId { get; set; }

    }
}
