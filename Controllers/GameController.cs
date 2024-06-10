using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class GameController : Controller
    {
        private const string SessionKeyNumber = "_Number";
        private const int MinNumber = 1;
        private const int MaxNumber = 100;

        [HttpGet]
        public ActionResult Index()
        {
            int randomNumber;

            if (HttpContext.Session.GetInt32(SessionKeyNumber) == null)
            {
                randomNumber = new Random().Next(MinNumber, MaxNumber + 1);
                HttpContext.Session.SetInt32(SessionKeyNumber, randomNumber);
                HttpContext.Session.SetInt32("GuessCount", 0);
            }
            else
            {
                randomNumber = HttpContext.Session.GetInt32(SessionKeyNumber).Value;
            }

            var model = new GuessingGame
            {
                RandomNumber = randomNumber,
                GuessCount = HttpContext.Session.GetInt32("GuessCount").Value
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(GuessingGame model)
        {
            if (ModelState.IsValid)
            {
                int randomNumber = HttpContext.Session.GetInt32(SessionKeyNumber).Value;
                int guessCount = HttpContext.Session.GetInt32("GuessCount").Value;
                guessCount++;

                if (model.Guess == randomNumber)
                {
                    ViewBag.Message = "Congratulations! You guessed the correct number.";
                    HttpContext.Session.SetInt32(SessionKeyNumber, new Random().Next(MinNumber, MaxNumber + 1));
                    HttpContext.Session.SetInt32("GuessCount", 0);
                }
                else if (model.Guess < randomNumber)
                {
                    ViewBag.Message = "Too low. Try again.";
                }
                else
                {
                    ViewBag.Message = "Too high. Try again.";
                }

                ViewBag.GuessCount = guessCount;
                HttpContext.Session.SetInt32("GuessCount", guessCount);
            }

            return View(model);
        }
    }
}

