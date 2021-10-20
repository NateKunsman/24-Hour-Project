using _24Hour.Data;
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

        public bool CreateComment(Comment model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = _userId,
                    Title = model.Title,
                    Text = model.Text
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new Comment
                        {
                            AuthorId = _userId,
                            Title = e.Title,
                            Text = e.Text
                        }
                        );
                return query.ToArray();
                
            }
        }

        public Comment GetCommentByID(int Id)
        {

        }

        public bool UpdateComment(Comment model)
        {

        }

        public bool DeleteComment(int Id)
        {

        }


    }
}
