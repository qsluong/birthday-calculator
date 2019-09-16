using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BirthdayCalculator.Models;

namespace BirthdayCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.CurrentDate = DateTime.Now.Date.ToLongDateString();
            return View();
        }

        [HttpGet]
        public ViewResult PersonalDataForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult PersonalDataForm(PersonalData personalData)
        {
            if (personalData.CalculateDaysLeft() == 0)
            {
                return View("Congratulations", personalData);
            }
            return View("Calculated", personalData);
        }
    }
}
