using _24Hour.Data;
using _24Hour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Service
{
    public class ReplyService
    {
        private readonly Guid _replyId;

        public ReplyService(Guid replyId)
        {
            _replyId = replyId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    ReplyId = _replyId,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary =
                    ctx
                        .Reply
                        .Where(e => e.AuthorId == _replyId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return quary.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reply
                        .Single(e => e.ReplyId == id && e.AuthorId == _replyId);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reply
                        .Single(e => e.ReplyId == model.NoteId && e.AuthorId == _replyId);
                entity.Content = model.Content;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reply
                        .Single(e => e.ReplyId == noteId && e.AuthorId == _replyId);
                ctx.Reply.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
