using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Domain.Models
{
    public static class MyExtensions
    {
        #region Text Extensions
        public static string cut(this string content, int dolzina)
        {
            if (content == null)
                return "";
            else if (content.Length > dolzina)
                return content.Substring(0, dolzina) + "...";
            else
                return content;
        }

        public static string CleanCut(this string content, int dolzina = 50)
        {
            if (content == null)
                return "";
            else if (content.Length > dolzina)
                return content.Substring(0, dolzina);
            else
                return content;
        }
        public static string cleanAndCut(this string content, int dolzina)
        {
            return content.cleanHtml().cut(dolzina);
        }
        public static string decodeCleanCut(this string content, int dolzina)
        {
            return content.decode().cleanAndCut(dolzina);
        }
        public static string latinFromCyrillic(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = str.Replace("а", "a");
                str = str.Replace("А", "A");

                str = str.Replace("б", "b");
                str = str.Replace("Б", "B");

                str = str.Replace("в", "v");
                str = str.Replace("В", "V");

                str = str.Replace("г", "g");
                str = str.Replace("Г", "G");

                str = str.Replace("д", "d");
                str = str.Replace("Д", "D");

                str = str.Replace("ѓ", "g");
                str = str.Replace("Ѓ", "G");

                str = str.Replace("е", "e");
                str = str.Replace("Е", "E");

                str = str.Replace("ж", "zh");
                str = str.Replace("Ж", "Zh");

                str = str.Replace("з", "z");
                str = str.Replace("З", "Z");

                str = str.Replace("ѕ", "dz");
                str = str.Replace("Ѕ", "Dz");

                str = str.Replace("и", "i");
                str = str.Replace("И", "I");

                str = str.Replace("ј", "j");
                str = str.Replace("Ј", "J");

                str = str.Replace("к", "k");
                str = str.Replace("К", "K");

                str = str.Replace("л", "l");
                str = str.Replace("Л", "L");

                str = str.Replace("љ", "lj");
                str = str.Replace("Љ", "Lj");

                str = str.Replace("м", "m");
                str = str.Replace("М", "M");

                str = str.Replace("н", "n");
                str = str.Replace("Н", "N");

                str = str.Replace("њ", "nj");
                str = str.Replace("Њ", "Nj");

                str = str.Replace("о", "o");
                str = str.Replace("О", "O");

                str = str.Replace("п", "p");
                str = str.Replace("П", "P");

                str = str.Replace("р", "r");
                str = str.Replace("Р", "R");

                str = str.Replace("с", "s");
                str = str.Replace("С", "S");

                str = str.Replace("т", "t");
                str = str.Replace("Т", "T");

                str = str.Replace("ќ", "k");
                str = str.Replace("Ќ", "K");

                str = str.Replace("у", "u");
                str = str.Replace("У", "U");

                str = str.Replace("ф", "f");
                str = str.Replace("Ф", "F");

                str = str.Replace("х", "h");
                str = str.Replace("Х", "H");

                str = str.Replace("ц", "c");
                str = str.Replace("Ц", "C");

                str = str.Replace("ч", "ch");
                str = str.Replace("Ч", "Ch");

                str = str.Replace("џ", "dz");
                str = str.Replace("Џ", "Dz");

                str = str.Replace("ш", "sh");
                str = str.Replace("Ш", "Sh");
            }
            return str;
        }
        public static string cyrilicFromLatin(this string str)
        {
            str = str.Replace("ch", "ч");
            str = str.Replace("Ch", "Ч");

            str = str.Replace("dz", "џ");
            str = str.Replace("Dz", "Џ");

            str = str.Replace("sh", "ш");
            str = str.Replace("Sh", "Ш");

            str = str.Replace("nj", "њ");
            str = str.Replace("Nj", "Њ");

            str = str.Replace("lj", "љ");
            str = str.Replace("Lj", "Љ");

            str = str.Replace("dz", "ѕ");
            str = str.Replace("Dz", "Ѕ");

            str = str.Replace("zh", "ж");
            str = str.Replace("Zh", "Ж");

            str = str.Replace("a", "а");
            str = str.Replace("A", "А");

            str = str.Replace("b", "б");
            str = str.Replace("B", "Б");

            str = str.Replace("v", "в");
            str = str.Replace("V", "В");

            str = str.Replace("g", "г");
            str = str.Replace("G", "Г");

            str = str.Replace("d", "д");
            str = str.Replace("D", "Д");

            str = str.Replace("g", "ѓ");
            str = str.Replace("G", "Ѓ");

            str = str.Replace("e", "е");
            str = str.Replace("E", "Е");

            str = str.Replace("z", "з");
            str = str.Replace("Z", "З");

            str = str.Replace("i", "и");
            str = str.Replace("I", "И");

            str = str.Replace("j", "ј");
            str = str.Replace("J", "Ј");

            str = str.Replace("k", "к");
            str = str.Replace("K", "К");

            str = str.Replace("l", "л");
            str = str.Replace("L", "Л");

            str = str.Replace("m", "м");
            str = str.Replace("M", "М");

            str = str.Replace("n", "н");
            str = str.Replace("N", "Н");

            str = str.Replace("o", "о");
            str = str.Replace("O", "О");

            str = str.Replace("p", "п");
            str = str.Replace("P", "П");

            str = str.Replace("r", "р");
            str = str.Replace("R", "Р");

            str = str.Replace("s", "с");
            str = str.Replace("S", "С");

            str = str.Replace("t", "т");
            str = str.Replace("T", "Т");

            str = str.Replace("k", "ќ");
            str = str.Replace("K", "Ќ");

            str = str.Replace("u", "у");
            str = str.Replace("U", "У");

            str = str.Replace("f", "ф");
            str = str.Replace("F", "Ф");

            str = str.Replace("h", "х");
            str = str.Replace("H", "Х");

            str = str.Replace("c", "ц");
            str = str.Replace("C", "Ц");

            return str;
        }
        public static string oneSpace(this string zbor)
        {
            return Regex.Replace(zbor, @"\s+", " ");
        }
        public static string toUpper(this string str)
        {
            return str != null ? str.ToUpper() : "";
        }
        public static string wrapQuotes(this string str)
        {
            return '"' + str + '"';
        }

        public static string MakeUniqueUrl(this string Url,int num)
        {
            return Url + "-" + num.ToString();
        }
        public static string friendlyUrl(this string url)
        {
            return url.Replace(" ", "-").latinFromCyrillic();
        }
        public static string TrimAddDashToLatin(this string words, int objID)
        {
            return words.Trim().Replace(" ", "-").Replace("/", "-").Replace("\\", "-").ToLower().latinFromCyrillic().CleanCut() + "-" + objID.ToString();
        }
        public static string TrimToLatinReplaceSpecial(this string words)
        {
            //return words.Trim().Replace(" ", "-").Replace("/", "-").Replace("\\", "-").
            //                    Replace(".","").Replace("@","").Replace("#","").Replace("$","").Replace("^","").ToLower().latinFromCyrillic().CleanCut();
            return Regex.Replace(words.Trim().ToLower().latinFromCyrillic().CleanCut(), "[^0-9a-zA-Z]+", "");
        }
        public static string TrimToLatinReplaceSpecialImage(this string words)
        {
            //return words.Trim().Replace(" ", "-").Replace("/", "-").Replace("\\", "-").
            //                    Replace(".","").Replace("@","").Replace("#","").Replace("$","").Replace("^","").ToLower().latinFromCyrillic().CleanCut();
            return Regex.Replace(words.Trim().ToLower().latinFromCyrillic().CleanCut(), "[^0-9a-zA-Z]+", "-");
        }
        public static string TrimAddDashToLatin(this string words)
        {
            return words.Trim().Replace(" ", "-").Replace("/", "-").Replace("\\", "-").ToLower().latinFromCyrillic().CleanCut();
        }

        public static string FixUrl(this string Url)
        {
            return Url.Replace("/", "\\");
        }
        public static string unfriendlyUrl(this string url)
        {
            return url.cyrilicFromLatin().Replace("-", " ");
        }
        #endregion

        #region Html Extensions
        public static string cleanHtml(this string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
        public static string decode(this string source)
        {
            if (source != null)
            {
                return HttpUtility.HtmlDecode(source);
            }
            else
                return "";
        }
        public static string encode(this string source)
        {
            if (source != null)
            {
                return HttpUtility.HtmlEncode(source);
            }
            else
                return "";
        }
        #endregion

        #region DateTime Extensions
        public static string formatDate(this DateTime dt, string str)
        {
            return dt.ToString(str).ToString();
        }
        public static string formatDateCulture(this DateTime dt, string str, string c)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(c);
            return dt.ToString(str, culture).ToString();
        }

        public static string formatDate(this DateTime dt)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("mk-MK");
            return dt.ToString("dd.MM.yyyy", culture).ToString();
        }

        #endregion

        #region Ladybook Extensions
        public static string getRowStyle(this int brojce)
        {
            return brojce == 0 ? "style='background-color:#fff !important;'" : "style='background-color:#f7f7f7 !important;'";
        }
        public static string FriendlyTitle(this string title)
        {
            return title.Replace(" ", "-");
        }
        public static string UnFriendlyTitle(this string title)
        {
            return title.Replace("-", " ");
        }
        public static string cleanUrl(this string url)
        {
            string clean = Regex.Replace(url.Replace(" ", "-").Replace("–", "-").Replace("---", "-").Replace("--", "-"), "[^a-zA-Z0-9а-шА-ШјЈќЌњЊѓЃѕЅ_.-]+", "", RegexOptions.Compiled);
            return clean.latinFromCyrillic();
        }
        public static string getSubClass(this int i)
        {
            if (i % 2 == 0)
                return "statija-mala-wrap ml0";
            else
                return "statija-mala-wrap mr0";
        }
        #endregion


        public static string formatDatePicker(this DateTime? date)
        {
            DateTime UpdatedDate = date ?? DateTime.Now;
            return UpdatedDate.ToString("dd/MM/yyyy");
        }
        public static string formatVisitTime(this DateTime? date)
        {
            return Convert.ToDateTime(date).ToString("dd/MM/yyyy HH:mm");
        }
        public static string formatMacedonianDate(this DateTime date, string cultureName)
        {
            return date.ToString("dd.MM.yyyy", new System.Globalization.CultureInfo(cultureName));
        }

        public static string RenderViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view,
                                            context.Controller.ViewData,
                                            context.Controller.TempData,
                                            sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
        
        public static string ToNumber(this int num)
        {
            return num.ToString("N", new CultureInfo("is-IS"));
        }
        public static string ToNumber(this double num)
        {
            return num.ToString("N", new CultureInfo("is-IS"));
        }
        public static string ToNumber(this float num)
        {
            return num.ToString("N", new CultureInfo("is-IS"));
        }
        public static string getValuta(this string valuta)
        {
            return !String.IsNullOrEmpty(valuta) ? valuta : "денари";
        }
        //public static string Translate(this List<Translate> tList, string toTranslate, string lang = "mk")
        //{
        //    Translate toReturn = tList.Where(c => c.Language.ShortName == lang && c.BaseName == toTranslate).FirstOrDefault();
        //    return toReturn == null ? toTranslate : toReturn.Translation.ToString();
        //}
        //public static string Translate(this List<Translate> tList, string toTranslate,string trType, string lang = "mk")
        //{
        //    Translate toReturn = tList.Where(c => c.Language.ShortName == lang && c.BaseName == toTranslate && c.TranslateType.Name == trType).FirstOrDefault();
        //    return toReturn == null ? toTranslate : toReturn.Translation.ToString();
        //}
        public static string hideIfEmpty(this string value)
        {
            string toReturn = "hide";
            if (!String.IsNullOrEmpty(value))
                toReturn = value.Trim();
            return toReturn;
        }
        //public static string HideIfEmptyList(this List<ProjectApartments> ApartmentTypes)
        //{
        //    return ApartmentTypes.Any() ? "" : "hide";
        //}
        public static string hideIfFalse(this bool value)
        {
            string toReturn = "hide";
            if (value)
                toReturn = "";
            return toReturn;
        }
        public static string translateBool(this bool value)
        {
            return value == true ? "Да" : "Не";
        }

        #region Language Extensions
        public static string Status(this bool status)
        {
            if (status)
                return "Активен";
            else
                return "Неактивен";
        }

        #endregion

        //public static PageItems getByLan(this List<PageItems> pi, string lan)
        //{
        //    PageItems res = new PageItems();
        //    PageItems item = pi.Where(c => c.Language.ShortName == lan).FirstOrDefault();
        //    if (item == null)
        //        return res;
        //    else
        //        return item;
        //}
        //public static string getByLan(this List<Tags> tagList, string lanShortName)
        //{
        //    Tags tr = tagList.Where(c => c.Lan == lanShortName).FirstOrDefault();
        //    return tr != null ? tr.Tag : "";
        //}

        //public static List<RelatedProduct> getByRelatedType(this List<RelatedProduct> items, bool type)
        //{
        //    return items.Where(c => c.SimularProduct == type).ToList();
        //}

        public static string getPhoto(this List<File> items)
        {
            string res = "nophoto.jpg";
            res = items != null && items.Any() ? items.FirstOrDefault().Link : res;
            return res;
        }
        public static string getUserPhoto(this List<File> items)
        {
            string res = "/Data/Images/Users/anonymousUser.jpg"; /*"C:/Users/office/Desktop/REPOS/target-oglasi/Oglasnik/Oglasnik/Data/Images/Users/no-user-image.jpg";*/
            res = items != null && items.Any() ? items.FirstOrDefault().Link : res;
            return res;
        }
        //public static string CheckActiveLanguage(this Language lan, string currentLang, string s)
        //{
        //    return lan.ShortName == currentLang ? s : "";
        //}
        //public static string ActiveLanguageHide(this Language lan, string currentLang)
        //{
        //    return lan.ShortName == currentLang ? "" : "hidden";
        //}

        //public static string getPhotoByType(this List<File> items, string type)
        //{
        //    File item = items.Where(c => c.FileType.Name == type).FirstOrDefault();
        //    return item != null ? item.Link : "";
        //}

        //public static string getVideoLink(this Video item)
        //{
        //   return item.File != null ? item.File.Link : !String.IsNullOrEmpty(item.VideoUrl) ? item.VideoUrl : "";
        //}

        //public static bool getType(this Video item)
        //{
        //    return item.File != null ? true : false;
        //}

        public static string setActiveClass(this string lan, string activeLan)
        {
            return lan == activeLan ? "active" : "";
        }

        public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(principal.IsInRole);
        }

        public static string getCategoryTranslation(this string queryString)
        {
            string result = "категории";
            if (!String.IsNullOrEmpty(queryString) && queryString== "subcategory")
            {
                result = "поткатегории";
            }
            return result;
        }
        public static string getBoolTextActive(this bool active)
        {
            return active ? "Активен" : "Неактивен";
        }

        public static string RemovePhotoText(this string content)
        {
            bool hasText = true;
            int br = 1;
            while (hasText)
            {
                if (content.Contains("(photo" + br + ")"))
                {
                    content = content.Replace("(photo" + br + ")", "");
                    br++;
                }
                else {
                    hasText = false;
                }
            }
            return content;
        }

        //public static string SetDropDownListCategories(this List<Category> items, List<Category> AllCategories)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    //sb.Append("<select name='CategoryIDs' class='chosen-select form-control' multiple='multiple'>");
        //    foreach(var item in AllCategories)
        //    {
        //        string selected = items.Where(c => c.ID == item.ID).Any() ? "selected='selected'" : "";
        //        sb.Append("<option " + selected + " value=" + item.ID + "'>" + item.CategoryTitle + "</option>");
        //    }
        //    //sb.Append("</select>");
        //    return sb.ToString();
        //}
        //public static string SetDropDownList(this List<AtributeName> items, List<AtributeName> AllAtributeNames)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<select class='chosen-select form-control' multiple='multiple'>");
        //    foreach (var item in AllAtributeNames)
        //    {
        //        string selected = items.Where(c => c.ID == item.ID).Any() ? "selected='selected'" : "";
        //        sb.Append("<option " + selected + " value='" + item.ID + "'>" + item.AtrName + "</option>");
        //    }
        //    sb.Append("</select>");
        //    return sb.ToString();
        //}

        public static List<File> thumbsImages(this List<File> images,string type)
        {
            return images.Where(c => c.FileType.FileTypeName == type).ToList();
        }

    }
}