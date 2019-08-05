using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugPages.Common;
using BugPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugPages.Controllers
{
    public class CommentController : Controller
    {
        private readonly LiteDbContext _db;

        public CommentController(LiteDbContext db)
        {

            _db = db;
        }

        [Route("api/comment/{bugid}")]
        public IActionResult Get(int bugId)
        {
            var model = _db.Context.GetCollection<Bug>().FindById(bugId);
            return Ok(model);
        }

        public IActionResult Post(int bugId,Comment model)
        {
            var bug = _db.Context.GetCollection<Bug>().FindById(bugId);
            bug.Comments.Add(model);

            var bugs = _db.Context.GetCollection<Bug>();
            bugs.Update(bug);

            return Ok(model);


        }
    }
}