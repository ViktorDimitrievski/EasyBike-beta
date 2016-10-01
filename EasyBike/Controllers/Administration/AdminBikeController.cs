using DataAccess.Logic;
using Domain.Models;
using Domain.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyBike.Controllers.Administration
{
    public class AdminBikeController : Controller
    {
        // GET: AdminBake
        public ActionResult Index()
        {
            ViewBag.ControllerName = "AdminBike";
            return View(BikeManager.GetAll());
        }

        public ActionResult Create()
        {
            return View(new AdminBikeView(new Bike()));
        }
        
        [HttpPost]
        public ActionResult Create(AdminBikeView Model)
        {
            AdminBikeView item = BikeManager.Create(Model);

            return Redirect("/backend/AdminBike/Edit/" + item.Bike.ID);
        }
        public ActionResult Edit(int id)
        {
            return View(BikeManager.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(AdminBikeView Model)
        {
            AdminBikeView item = BikeManager.Edit(Model);

            return Redirect("/backend/AdminBike/Edit" + item.Bike.ID);
        }

    }
}