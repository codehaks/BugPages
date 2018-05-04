using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugPages.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugPages.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Bug> Bugs { get; set; }
        public void OnGet()
        {
            using (var db = new LiteDatabase(@"bug.db"))
            {
                var bugs = db.GetCollection<Bug>();
                Bugs = bugs.FindAll();

            }
        }
    }
}