using BugPages.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BugPages.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Bug> Bugs { get; set; }
        public void OnGet()
        {
            using (var db = new LiteDatabase("bug.db"))
            {
                var bugs = db.GetCollection<Bug>();
                Bugs = bugs.FindAll();
            }
        }
    }
}