using _24Hour.Data;
using _24Hour.Model;
using _24Hour.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.Controllers
{

    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int iD)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentByID(iD);
            return Ok(comment);
        }

        public IHttpActionResult Put(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.UpdateComment(comment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int iD)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(iD))
                return InternalServerError();
            return Ok();
        }

    }
}
