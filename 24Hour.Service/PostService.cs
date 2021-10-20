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
        public PostService(int userId)
        { _userId = userId; }
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
        public IEnumerable<PostList> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.User
                        .Where(e => e.Id == _userId)
                        .Select(e => new PostList
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Content = e.Content,
                            AuthorId = e.AuthorId

                        }
                        );
                return query.ToArray();
            }
        }




        //GetbyId


        //Update


        //Delete
    }
}
