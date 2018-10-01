using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugPages.Common;
using BugPages.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugPages.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Bug Bug { get; set; }

        private readonly LiteDbContext _db;

        public CreateModel(LiteDbContext db)
        {
            _db = db;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //using (var db = new LiteDatabase(@"bug.db"))
            //{
            //    var bugs = db.GetCollection<Bug>();
            //    bugs.Insert(Bug);

            //}

            var bugs = _db.Database.GetCollection<Bug>();
            bugs.Insert(Bug);

            return RedirectToPage("./index");

        }
    }
}