using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugPages.Controllers
{
    public class TestController : Controller
    {
        [Route("test/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("test/create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("test/create")]
        [HttpPost]
        public IActionResult Create(IList<Bug> bugs)
        {
            return View();
        }

    }
}