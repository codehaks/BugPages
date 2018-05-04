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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Bug Bug { get; set; }

        public void OnGet(int id)
        {
            using (var db = new LiteDatabase(@"bug.db"))
            {
                Bug = db.GetCollection<Bug>().FindById(id);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var db = new LiteDatabase(@"bug.db"))
            {
                var bugs = db.GetCollection<Bug>();
                bugs.Update(Bug);

            }
            return RedirectToPage("./index");

        }
    }
}