using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Flix.API.Models;

namespace Flix.API.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TheMoviedb 
    {
        public Search GetPopularity()
        {
            string JSon = null;
            string apiKey = "?api_key=4311ad461d9e5136c6bd9a5044968836";
            string apiUrl = "https://api.themoviedb.org/3/discover/movie";
            string popularity = "&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1"; //to update this for page views update number for int
            string apiString =  apiUrl + apiKey + popularity;
            WebRequest requestObject = WebRequest.Create(apiString);
            requestObject.Method = "GET";
            HttpWebResponse responseObjGet = (HttpWebResponse)requestObject.GetResponse();

            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                JSon = sr.ReadToEnd();
                sr.Close();
            }

             var items = JsonConvert.DeserializeObject<Search>(JSon);

  

            return items;
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiIntergrationExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TheMoviedb>();
        }
    }
}
