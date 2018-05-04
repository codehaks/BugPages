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
    public class DeleteModel : PageModel
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
            using (var db = new LiteDatabase(@"bug.db"))
            {
                var bugs = db.GetCollection<Bug>();
                bugs.Delete(Bug.Id);

            }
            return RedirectToPage("./index");

        }
    }
}