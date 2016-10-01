using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Logic
{
    public class SexManager
    {
        public static List<Sex> GetAll()
        {
            using (Baza db = new Baza())
            {
                return db.Sex.ToList();
            }
        }
    }
}