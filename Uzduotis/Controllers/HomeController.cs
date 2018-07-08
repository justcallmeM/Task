using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uzduotis.Models;

namespace Uzduotis.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            var req = WebRequest.Create(@"https://api.themoviedb.org/3/movie/popular?api_key=f0bf2d5d3612c88c114facab516e9b87&language=en-US&page=1");
            var r = await req.GetResponseAsync().ConfigureAwait(false);

            var responseReader = new StreamReader(r.GetResponseStream());
            var responseData = await responseReader.ReadToEndAsync();

            var d = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(responseData);
            return View(d);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
