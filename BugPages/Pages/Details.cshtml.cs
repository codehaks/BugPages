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
    public class DetailsModel : PageModel
    {

      
        public Bug Bug { get; set; }

        public void OnGet(int id)
        {
            using (var db = new LiteDatabase(@"bug.db"))
            {
                Bug = db.GetCollection<Bug>().FindById(id);
            }
        }
    }
}