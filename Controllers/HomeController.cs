using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult YourDojoDachi()
        {
            Dojodachi YourPet = null;
            if(HttpContext.Session.GetString("YourPet") == null)
            {
                YourPet = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("YourPet",YourPet);
            }
            else
            {
                YourPet = HttpContext.Session.GetObjectFromJson<Dojodachi>("YourPet");
            }
            return View("YourDojoDachi",YourPet);
        }

        [HttpPost("Feed")]
        public IActionResult Feed()
        {
            Dojodachi YourPet = HttpContext.Session.GetObjectFromJson<Dojodachi>("YourPet");
            YourPet.Eat();
            HttpContext.Session.SetObjectAsJson("YourPet",YourPet);
            return RedirectToAction("YourDojoDachi");
        }

        [HttpPost("Play")]
        public IActionResult Play()
        {
            Dojodachi YourPet = HttpContext.Session.GetObjectFromJson<Dojodachi>("YourPet");
            YourPet.Play();
            HttpContext.Session.SetObjectAsJson("YourPet",YourPet);
            return RedirectToAction("YourDojoDachi");
        }

        [HttpPost("Work")]
        public IActionResult Work()
        {
            Dojodachi YourPet = HttpContext.Session.GetObjectFromJson<Dojodachi>("YourPet");
            YourPet.Work();
            HttpContext.Session.SetObjectAsJson("YourPet",YourPet);
            return RedirectToAction("YourDojoDachi");
        }

        [HttpPost("Sleep")]
        public IActionResult Sleep()
        {
            Dojodachi YourPet = HttpContext.Session.GetObjectFromJson<Dojodachi>("YourPet");
            YourPet.Sleep();
            HttpContext.Session.SetObjectAsJson("YourPet",YourPet);
            return RedirectToAction("YourDojoDachi");
        }

        [HttpPost("Reset")]
        public IActionResult Reset()
        {
            Dojodachi YourPet = new Dojodachi();
            HttpContext.Session.SetObjectAsJson("YourPet",YourPet);
            return RedirectToAction("YourDojoDachi");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
