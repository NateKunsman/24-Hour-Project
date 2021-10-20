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
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
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
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == Id && e.AuthorId == _userId);
                return
                    new Comment
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Title = entity.Title
                    };
            }
        }

        public bool UpdateComment(Comment model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == model.Id && e.AuthorId == _userId);
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == Id && e.AuthorId == _userId);
                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }


        }
    }
}
