using Microsoft.AspNetCore.Mvc;
using LFYS_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace LFYS_Project.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly WlfysProjContext _context = new WlfysProjContext();
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Detail(int id = 0)
        {
            var course = _context.Courses.Find(id);
            return View(course);
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult Video(int id = 0)
        {
            var video = _context.Videos.Find(id);
            return View(video);
        }
    }
}
