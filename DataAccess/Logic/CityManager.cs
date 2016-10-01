using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Logic
{
    public class CityManager
    {
        public static List<City> GetAll()
        {
            using (Baza db = new Baza())
            {
                
                return db.City.ToList();
            }
        }
    }
}