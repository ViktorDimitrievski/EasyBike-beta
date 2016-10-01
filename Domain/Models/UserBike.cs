using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class UserBike
    {
        public int ID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public int UserID { get; set; }

        public virtual Bike Bike { get; set; }
        public int BikeID { get; set; }



    }
}