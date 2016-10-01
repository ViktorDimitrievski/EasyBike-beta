using DataAccess.Logic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.DbAccess
{
    public class FileQueries
    {
        public static List<File> GetAll()
        {
            using (Baza db = new Baza())
            {
                return db.File.ToList();
            }
        }

        public static File GetById(int id)
        {
            using (Baza db = new Baza())
            {
                return db.File.Where(c => c.ID == id).FirstOrDefault();
            }
        }
        public static bool Delete(int id)
        {
            using (Baza db = new Baza())
            {
                bool status = false;
                File item = db.File.Where(c => c.ID == id).FirstOrDefault();

                if(item != null)
                {
                    FileManager.DeleteFile(item);
                    db.File.Remove(item);
                }

                try
                {
                    db.SaveChanges();
                    status = true;
                }
                catch(Exception e)
                {
                    throw;
                }

                return status;
            }
        }

        internal static int GetTypeByName(string filetype)
        {
            using (Baza db = new Baza())
            {
                return db.FileType.Where(c => c.FileTypeName == filetype).FirstOrDefault().ID;
            }
        }

        internal static FileType getFileTypeByName(string fileType)
        {
            using (Baza db = new Baza())
            {
                return db.FileType.Where(c => c.FileTypeName == fileType).FirstOrDefault();
            }
        }

        internal static File Get(int id)
        {
            using (Baza db = new Baza())
            {
                return db.File.Where(c => c.ID == id).FirstOrDefault();
            }
                
        }
    }
}