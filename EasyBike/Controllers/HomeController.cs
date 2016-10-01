using DataAccess.Logic;
using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyBike.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult BikeLocation()
        {
            LocationViewModel item = new LocationViewModel();
            item.Cities = CityManager.GetAll();
            return View(item);
        }


        public JsonResult GetBikeLocation(int cityID)
        {
            LocationViewModel item = BikeManager.GetByCity(cityID);

            return Json(new { item = item }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Rent()
        {
            RentView item = new RentView();
            return View(item);
        }
        [HttpPost]
        public ActionResult Rent(RentView Model)
        {
            bool status = BikeManager.CheckIfValid(Model.BikeCode);
            if (status)
                return Redirect("/Home/RentStatus");
            else
                return View();
        }

        public ActionResult RentStatus()
        {
            var hours = BikeManager.CheckCredits(HttpContext.User.Identity.Name);
            RentView model = new RentView();
            model.HoursLeft = hours;
            return View(model);
        }
    }
}