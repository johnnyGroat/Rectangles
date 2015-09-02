using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rectangles.Models;

namespace Rectangles.Controllers
{
    public class HomeController : Controller  
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckRectangles(string rectangle1Vertices,  string rectangle2Vertices)
        {
            RectanglePair rectanglePair = new RectanglePair(Newtonsoft.Json.JsonConvert.DeserializeObject<Rectangle>(rectangle1Vertices), Newtonsoft.Json.JsonConvert.DeserializeObject<Rectangle>(rectangle2Vertices));

            return View();
        }
    }
}