using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _24Hour.Model;
using _24Hour.Service;
using _24Hour.Data;
using Microsoft.AspNet.Identity;

namespace _24HourProject.Controllers
{
    //POST(Create) a Reply to a Comment using a Foreign Key relationship(required)
    //GET Replies By Comment Id(required)
    //GET Reply By Author Id
    //PUT(Update) a Reply
    //DELETE a Reply
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var Id = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(Id);
            return replyService;
        }
        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReply();
            return Ok(reply);
        }

        public IHttpActionResult Reply(Reply reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            ReplyService noteService = CreateReplyService();
            var post = noteService.GetReplyById(id);
            return Ok(post);
        }
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.UpdateReply(reply))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();
            if (!service.DeleteNote(id))
                return InternalServerError();
            return Ok();
        }
    }
}
