using _24Hour.Data;
using _24Hour.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _24HourProject.Controllers
{
    public class PostController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostUser(Users model)
        {
            if (model == null)
                return BadRequest("Please Enter Correct Information");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.User.Add(model);

            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok($"{model.Title} was added to the database");
            }
            return InternalServerError();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllPost()
        {
            return Ok(await _context.User.ToListAsync());

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Users users = await _context.User.FindAsync(id);

            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        /*[HttpPut]
        public async Task<IHttpActionResult> UpdatebyId(int id, Users model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest("Try Again");

            Users users = await _context.User.FirstAsync(id);
        }*/
    }
}
