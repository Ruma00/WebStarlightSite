using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarlightProject_Site.Data;
using StarlightProject_Site.Models;

namespace StarlightProject_Site.Controllers
{
    public class StoriesController : Controller
    {
        ApplicationDbContext _context;

        public StoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Stories()
        {
            return View();
        }

        public IActionResult Story(int id)
        {
            return View(new StoryModel("The test story", id, "test1"));
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Library()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddStory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddStory(StoryModel model, string text)
        {
            if (ModelState.IsValid)
            {
                string path = "wwwroot/static/stories/";
                int number = GetLast();
                path += number;

                model.StoryID = number;
                model.StoryImg = number + ".jpg";

                /*using (var fileStream = new FileStream("wwwroot/img/stories/" + number + ".jpg", FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }*/

                _context.Add(model);
                await _context.SaveChangesAsync();

                StreamWriter writer = new StreamWriter(path + ".html", false);

                writer.WriteLine(text);

                writer.Close();
            }

            return View();
        }

        private int GetLast()
        {
            int num;
            using (StreamReader reader = new StreamReader("wwwroot/static/Last.txt"))
            {
                num = Convert.ToInt32(reader.ReadLine());

                StreamWriter writer = new StreamWriter("wwwroot/static/Last.txt", false);
                writer.WriteLine(num + 1);
                writer.Close();
            }
            return num;
        }
    }
}