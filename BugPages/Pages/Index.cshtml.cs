using BugPages.Common;
using BugPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading;

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
            Thread.Sleep(5000);
            return new JsonResult(Bugs);
        }
    }
}