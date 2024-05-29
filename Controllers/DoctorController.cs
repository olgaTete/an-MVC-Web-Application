using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Temperature()
        {
            return View();
        }

        public IActionResult Temperature(float temperature, string scale)
        {
            string result = TempUtility.Temperature(temperature, scale);
            ViewData["Message"] = result;
            return View();
        }
    }
}
