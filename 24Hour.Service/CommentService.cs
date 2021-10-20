using _24Hour.Model;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _24Hour.Service
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        { _userId = userId; }

        public bool Create(Comment model)
        {
            var entity = 
                new Comment()
                { 
                    Title = model.Title,

                }
        }

    }
}
