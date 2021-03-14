using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Util.View
{
    public static class URLUtil
    {

        //Taken from: https://stackoverflow.com/questions/42022311/asp-net-mvc-create-action-link-preserve-query-string
        public static string Current(this IUrlHelper helper, object substitutes)
        {
            RouteValueDictionary routeData = new RouteValueDictionary(helper.ActionContext.RouteData.Values);
            IQueryCollection queryString = helper.ActionContext.HttpContext.Request.Query;

            //add query string parameters to the route data
            foreach (var param in queryString)
            {
                if (!string.IsNullOrEmpty(queryString[param.Key]))
                {
                    //rd[param.Key] = qs[param.Value]; // does not assign the values!
                    routeData.Add(param.Key, param.Value);
                }
            }

            // override parameters we're changing in the route data
            //The unmatched parameters will be added as query string.
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(substitutes.GetType()))
            {
                var value = property.GetValue(substitutes);
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    routeData.Remove(property.Name);
                }
                else
                {
                    routeData[property.Name] = value;
                }
            }

            string url = helper.RouteUrl(routeData);
            return url;
        }

    }
}
