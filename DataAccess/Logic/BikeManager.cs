using Domain.Models;
using Domain.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.DbAccess;
using Domain.ViewModels;

namespace DataAccess.Logic
{
    public class BikeManager
    {
        public static AdminBikesView GetAll()
        {
            return BikeQueries.GetAll();
        }

        public static AdminBikeView Create(AdminBikeView model)
        {
            return BikeQueries.Create(model);
        }

        public static AdminBikeView GetByID(int id)
        {
            return BikeQueries.GetById(id);
        }

        public static AdminBikeView Edit(AdminBikeView model)
        {
            return BikeQueries.Edit(model);
        }

        public static LocationViewModel GetByCity(int cityID)
        {
            return BikeQueries.GetByCity(cityID);
        }

        public static bool CheckIfValid(string bikecode)
        {
            return BikeQueries.CheckIfValid(bikecode);
        }

        public static double CheckCredits(string name)
        {
           return BikeQueries.CheckCredits(name);
        }
    }
}