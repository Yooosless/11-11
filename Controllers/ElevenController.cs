//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Notes.Data;
//using Notes.Models;

//namespace Notes.Controllers
//{
//    public class ElevenController : Controller
//    {
//        private readonly ApplicationDbContext _db;
//        public ElevenController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        // GET: Eleven11
//        public IActionResult Index()
//        {
//            IEnumerable<Eleven11> objEleven = _db.Eleven11s;

//            return View(objEleven);
//        }



//        // GET: Eleven11/Create
//        public IActionResult Create()
//        {
//            return View();

//        }

//        // POST: Eleven11/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Eleven11 obj)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Eleven11s.Add(obj);
//                _db.SaveChanges();
//                TempData["success"] = "Note has been added!";
//                return RedirectToAction("Index");
//            }
//            return View(obj);
//        }


//    }
//}
using Microsoft.AspNetCore.Mvc;
using Notes.Data;
using Notes.Models;

namespace Notes.Controllers
{
    public class ElevenController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ElevenController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime startTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 00, 00, 00);
            DateTime endTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);

            if (currentTime >= startTime && currentTime <= endTime)
            {
                IEnumerable<Eleven11> objEleven = _db.Eleven11s;
                return View(objEleven);
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        public IActionResult Create()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime startTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 11, 00);
            DateTime endTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 12, 00);
            DateTime startTime2 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 11, 00);
            DateTime endTime2 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 12, 00);

            if (currentTime >= startTime && currentTime <= endTime)
            {
                return View();
            }
            else if (currentTime >= startTime2 && currentTime <= endTime2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}