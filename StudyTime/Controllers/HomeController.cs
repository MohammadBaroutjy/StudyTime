using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using StudyTime.Models;
using StudyTime.Services;
using System.Diagnostics;

namespace StudyTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HallService _hallService;

        public HomeController(ILogger<HomeController> logger,HallService hallService)
        {
            _hallService = hallService;
            _logger = logger;
           
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult GetHallsBySpecialty(string specialty,string year)
        {
            var table = _hallService.GetHallsBySpecialty(specialty,year);
            ViewData["Title"] = specialty;
            return View(table);
        }

        public IActionResult HallsEmpty([FromQuery] string day,int time)
        {
            var halls = _hallService.GetHallIsEmptyByDayAndTime(day,time);
            ViewData["Day"] = day.ToDayArabic();
            ViewData["Time"] = time;
            return View(halls);
        }

    }
}