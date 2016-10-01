using DataAccess.DbAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAccess.Logic
{
    public class FileManager
    {
        public static List<File> GetAll()
        {
            return FileQueries.GetAll();
        }

        public static File createFile(HttpPostedFileBase file, string pat, string id, bool resize = false, int quality = 90, int typeID = 3, int width = 700, string _dateStamp = "")
        {
            File fi = new File();
            
            if (resize == true)
            {
                fi.Link = saveAndResizeImage(file, pat, id, width, quality, _dateStamp);
            }
            else
                fi.Link = saveImage(file, pat, id);

            fi.FileTypeID = typeID;
            fi.Link = fi.Link.Replace("\\", "/");
            fi.FileName = id + "_" + DateTime.Now.ToString("ddMMyyHHmmssfff") + "." + file.FileName.Split('.')[1];
            return fi;
        }
        public static int GetTypeByName(string filetype)
        {
            return FileQueries.GetTypeByName(filetype);
        }
        public static string CheckContentType(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return "image";
            }
            else
                return "document";
        }
        public static string saveImage(HttpPostedFileBase file, string pat, string id)
        {
            string fullPath = "";
            string[] FileNameParts = file.FileName.Split('.');
            string extension = FileNameParts[FileNameParts.Length - 1];
            string fileName = String.Join("-", FileNameParts.Reverse().Skip(1).Reverse().ToArray()).CleanCut(40);

            string ime = fileName + "_" + id + "_" + DateTime.Now.ToString("HHmmss") + "." + extension;
            file.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~") + pat + ime);
            return fullPath = pat + ime;
        }
        public static string saveFile(HttpPostedFileBase file, string pat, string id)
        {
            string sFileName;
            string fullPath = "";
            sFileName = System.IO.Path.GetFileName(file.FileName);
            string[] FileNameParts = file.FileName.Split('.');
            string ime = id + "_" + DateTime.Now.ToString("ddMMyyHHmmssfff") + "." + FileNameParts[FileNameParts.Length - 1];
            file.SaveAs(HttpContext.Current.Server.MapPath("~") + pat + "\\" + ime);
            fullPath = pat + ime;
            return fullPath;
            //return ime;
        }

        public static File Get(int id)
        {
            return FileQueries.Get(id);
        }
        public static bool Delete(int id)
        {
            return FileQueries.Delete(id);
        }
        public static File CreateFile(HttpPostedFileBase Image, string fileType, string FileName, string path)
        {

            FileType ft = FileQueries.getFileTypeByName(fileType);
            File newFile = new File();
            newFile.FileName = FileName + Image.FileName;
            newFile.FileTypeID = ft.ID;
            newFile.Link = path + FileName;

            return newFile;
        }
        public static File CopyImage(File Image, int ID)
        {
            string newLink = checkFileExist(Image, ID);

            File NewImage = new File()
            {
                FileTypeID = Image.FileTypeID,
                Link = newLink,
                FileName = Image.FileName,
                
            };

            System.IO.File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + Image.Link, System.Web.HttpContext.Current.Server.MapPath("~") + NewImage.Link);
            return NewImage;
        }

        public static void DeleteFile(File Image)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + Image.Link;
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }

        public static void DeleteFiles(List<File> Images)
        {
            foreach (File item in Images)
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~") + item.Link;
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
        }

        public static string checkFileExist(File Image, int ID)
        {
            string fullName = (Image.Link.Split('/')[Image.Link.Split('/').Length - 1]);
            string extension = fullName.Split('.').Last();
            string Name = fullName.Remove(fullName.LastIndexOf('.'));
            string newName = Name + "_" + ID;
            string fullLink = Image.Link.Remove(Image.Link.LastIndexOf('/'));

            bool exist = true;
            int br = 1;
            while (exist)
            {
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + fullLink + "\\" + newName + "." + extension))
                    newName = newName + "-" + br;
                else
                    exist = false;
            }
            return fullLink + "\\" + newName + "." + extension;
        }
        public static string saveAndResizeImage(HttpPostedFileBase file, string pat, int id, int width, int _quality)
        {
            Bitmap originalBMP;
            originalBMP = new Bitmap(file.InputStream);

            decimal origWidth = originalBMP.Width;
            decimal origHeight = originalBMP.Height;
            decimal sngRatio = origHeight / origWidth;
            int newWidth = width;
            if (origWidth < newWidth)
                newWidth = Convert.ToInt32(origWidth);
            int newHeight = Convert.ToInt32(newWidth * sngRatio);

            // Create a new bitmap which will hold the previous resized bitmap
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
            // Create a graphic based on the new bitmap
            Graphics oGraphics = Graphics.FromImage(newBMP);

            oGraphics.CompositingQuality = CompositingQuality.HighQuality;
            // Set the properties for the new graphic file
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            // Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

            // Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

            int quality = _quality;
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            //Save File on disk
            string ime = id + "_" + DateTime.Now.ToString("ddMMyyHHmmssfff") + "_" + origWidth.ToString() + "x" + origHeight.ToString() + ".jpg";
            // Save the new graphic file to the server
            newBMP.Save(HttpContext.Current.Server.MapPath("~") + pat + ime, getCodecInfo(getExtension(file.FileName)), parameters);


            // Once finished with the bitmap objects, we deallocate them.
            originalBMP.Dispose();
            newBMP.Dispose();
            oGraphics.Dispose();

            //return ime;
            return ime;

        }
        public static string saveAndResizeImage(HttpPostedFileBase file, string pat, string NameFromId, int width, int _quality, string _dateStamp = "")
        {
            Bitmap originalBMP;
            originalBMP = new Bitmap(file.InputStream);

            decimal origWidth = originalBMP.Width;
            decimal origHeight = originalBMP.Height;
            decimal sngRatio = origHeight / origWidth;
            int newWidth = width;
            if (origWidth < newWidth)
                newWidth = Convert.ToInt32(origWidth);
            int newHeight = Convert.ToInt32(newWidth * sngRatio);

            // Create a new bitmap which will hold the previous resized bitmap
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
            // Create a graphic based on the new bitmap
            Graphics oGraphics = Graphics.FromImage(newBMP);

            oGraphics.CompositingQuality = CompositingQuality.HighQuality;
            // Set the properties for the new graphic file
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            // Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

            // Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

            int quality = _quality;
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            //Save File on disk
            string dateStamp = !String.IsNullOrEmpty(_dateStamp) ? _dateStamp : DateTime.Now.ToString("ddMMyyHHmmssfff");
            string ime = NameFromId + "_" + dateStamp + "_" + origWidth.ToString() + "x" + origHeight.ToString() + ".jpg";
            // Save the new graphic file to the server
            newBMP.Save(HttpContext.Current.Server.MapPath("~") + pat + ime, getCodecInfo(getExtension(file.FileName)), parameters);


            // Once finished with the bitmap objects, we deallocate them.
            originalBMP.Dispose();
            newBMP.Dispose();
            oGraphics.Dispose();

            //return ime;
            return pat + ime;

        }
        private static ImageCodecInfo getCodecInfo(string mimeType)
        {
            foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
                if (encoder.MimeType == mimeType)
                    return encoder;
            throw new ArgumentOutOfRangeException(
                string.Format("'{0}' not supported", mimeType));
        }
        public static string getExtension(string fileName)
        {
            switch (fileName.Split('.')[1].ToLower())
            {
                case "bmp": return "image/bmp";
                case "gif": return "image/gif";
                case "jpg": return "image/jpeg";
                case "jpeg": return "image/jpeg";
                case "png": return "image/png";
                default: break;
            }
            return "";
        }

    }
}
 