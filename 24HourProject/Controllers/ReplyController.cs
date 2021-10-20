using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _24Hour.Model;
using _24Hour.Service;

namespace _24HourProject.Controllers
{
    //POST(Create) a Reply to a Comment using a Foreign Key relationship(required)
    //GET Replies By Comment Id(required)
    //GET Reply By Author Id
    //PUT(Update) a Reply
    //DELETE a Reply
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            PostService postService = CreatPostService();
            var post = postService.GetPosts();
            return Ok(post);
        }

        public IHttpActionResult Post(Reply post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.CreateNote(post))
                return InternalServerError();
            return Ok();
        }

        private PostService CreateReplyService()
        {
            var Id = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(Id);
            return postService;
        }
        public IHttpActionResult Get(int id)
        {
            PostService noteService = CreatePostService();
            var post = noteService.GetNoteById(id);
            return Ok(post);
        }
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.UpdateNote(post))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();
            if (!service.DeleteNote(id))
                return InternalServerError();
            return Ok();
        }
    }
}
