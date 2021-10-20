using _24Hour.Data;
using _24Hour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Service
{
    public class PostService
    {
        //CRUD
        //PGPD
        private readonly int _userId;
        //Create
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Users()
                {
                    Id = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = model.AuthorId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get


        //GetbyId


        //Update


        //Delete
    }
}
