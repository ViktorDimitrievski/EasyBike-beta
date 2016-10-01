using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DataAccess.Logic;
using Newtonsoft.Json;
using Domain.ViewModels.Administration;
using Domain.Models;
using Domain.ViewModels;

namespace DataAccess.DbAccess
{
    public class BikeQueries
    {
        public static AdminBikesView GetAll()
        {
            using (Baza db = new Baza())
            {
                List<Bike> bikes = db.Bike.Include(c => c.City).Include(c => c.Photos).ToList();

                return new AdminBikesView(bikes);
            }
        }

        internal static AdminBikeView Create(AdminBikeView model)
        {
            using (Baza db = new Baza())
            {
                db.Bike.Add(model.Bike);
                db.SaveChanges();

                if (model.Images[0] != null)
                {
                    var dateStamp = DateTime.Now.ToString("ddMMyyHHmmssfff");
                    foreach (var item in model.Images)
                    {
                        var fType = db.FileType.Where(c => c.FileTypeName == "Images").FirstOrDefault();
                        File fItem = FileManager.createFile(item, "\\Data\\Bikes\\", model.Bike.ID.ToString(), true, 90, fType.ID, 700, dateStamp);

                        if (model.Bike.Photos == null)
                            model.Bike.Photos = new List<File>();
                        model.Bike.Photos.Add(fItem);
                        //model.dbPhotos.Add(fItem);
                    }
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }

                return model;

            }
        }

        internal static double CheckCredits(string name)
        {
            using (Baza db = new Baza())
            {
                ApplicationUser user = db.Users.Where(c => c.UserName == name).FirstOrDefault();
                return user.Credit;
            }
        }

        internal static bool CheckIfValid(string bikecode)
        {
            using (Baza db = new Baza())
            {
                List<Bike> items = db.Bike.ToList();

                if (items.Where(c => c.BikeCode == bikecode).Any())
                    return true;
                else
                    return false;

            }
        }

        internal static LocationViewModel GetByCity(int cityID)
        {
            using (Baza db = new Baza())
            {
                List<Bike> items = db.Bike.Where(c => c.CityID == cityID).ToList();
                LocationViewModel result = new LocationViewModel()
                {

                    Bikes = items,
                    jsonBikes = JsonConvert.SerializeObject(items),
                    Cities = CityManager.GetAll()

                };


                return result;
            }
        }


        internal static AdminBikeView Edit(AdminBikeView model)
        {
            using (Baza db = new Baza())
            {
                Bike item = db.Bike.Where(c => c.ID == model.Bike.ID).FirstOrDefault();
                db.Entry(item).CurrentValues.SetValues(model.Bike);
                db.SaveChanges();

                if (model.Images[0] != null)
                {
                    var dateStamp = DateTime.Now.ToString("ddMMyyHHmmssfff");
                    foreach (var _item in model.Images)
                    {
                        var fType = db.FileType.Where(c => c.FileTypeName == "Images").FirstOrDefault();
                        File fItem = FileManager.createFile(_item, "\\Data\\Bikes\\", model.Bike.ID.ToString(), true, 90, fType.ID, 700, dateStamp);

                        if (item.Photos == null)
                            item.Photos = new List<File>();
                        item.Photos.Add(fItem);
                        //model.dbPhotos.Add(fItem);
                    }
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return model;
            }
        }

        internal static AdminBikeView GetById(int id)
        {
            using (Baza db = new Baza())
            {
                return new AdminBikeView(db.Bike.Where(c => c.ID == id).FirstOrDefault());
            }
        }
    }
}
