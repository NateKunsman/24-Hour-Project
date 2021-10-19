using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual string Text { get; set; }
        [Required]
        public Guid AutherId { get; set; }

    }
}
