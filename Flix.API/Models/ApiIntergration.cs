using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Flix.API.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiIntergration 
    {
        public void apiLoader()
        {
            string apiKey = "?api_key=4311ad461d9e5136c6bd9a5044968836";
            string apiUrl = "https://api.themoviedb.org/3/discover/movie";
            string popularity = "&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1";
            string apiString =  apiUrl + apiKey + popularity;
            WebRequest requestObject = WebRequest.Create(apiString);
            requestObject.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObject.GetResponse();

            string resultTest = null;

            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultTest = sr.ReadToEnd();
                sr.Close();
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiIntergrationExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiIntergration>();
        }
    }
}
