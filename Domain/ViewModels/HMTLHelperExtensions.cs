using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Domain.HelperModels
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string queryString = null)
        {
            string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];
            //string currentQueryString = HttpContext.Current.Request.QueryString["typecat"] != null ? HttpContext.Current.Request.QueryString["typecat"] : "";

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            //if (String.IsNullOrEmpty(queryString))
            //    queryString = currentQueryString;

            bool isController = controller.ToLower() == currentController.ToLower();
            bool isAction = action.ToLower() == currentAction.ToLower();
            //bool isQueryString = queryString.ToLower() == currentQueryString.ToLower();

            return isController && isAction ? cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

	}
}
