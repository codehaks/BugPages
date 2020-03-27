using BugPages.Common;
using BugPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BugPages.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Bug> Bugs { get; set; }
        public void OnGet([FromServices]LiteDbContext db)
        {

            var bugs = db.Context.GetCollection<Bug>();
            Bugs = bugs.FindAll();

        }

        public IActionResult OnGetBugData([FromServices]LiteDbContext db)
        {
            var bugs = db.Context.GetCollection<Bug>();
            Bugs = bugs.FindAll();
            return new JsonResult(Bugs);
        }
    }
}