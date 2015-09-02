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

            RectangleProperties pairProperties = new RectangleProperties();

            pairProperties.hasContainment = HasContainment(rectanglePair);
            pairProperties.hasAdjacency = HasAdjacency(rectanglePair);
            pairProperties.hasIntersection = (pairProperties.hasContainment ? false : HasIntersection(rectanglePair));
            

            rectanglePair.rectangleProperties = pairProperties;
            return Json(rectanglePair);
        }

        public bool HasIntersection(RectanglePair rectanglePair)
        {
            if (rectanglePair.rectangle1.xVertex1 < rectanglePair.rectangle2.xVertex2 && rectanglePair.rectangle1.xVertex2 > rectanglePair.rectangle2.xVertex1 && rectanglePair.rectangle1.yVertex1 > rectanglePair.rectangle2.yVertex2 && rectanglePair.rectangle1.yVertex2 < rectanglePair.rectangle2.yVertex1)
                return true;
            return false;
        }

        public bool HasAdjacency(RectanglePair rectanglePair)
        {
            //Right alignment
            if (rectanglePair.rectangle1.xVertex2 == rectanglePair.rectangle2.xVertex1 && ((rectanglePair.rectangle1.yVertex2 >= rectanglePair.rectangle2.yVertex2 && rectanglePair.rectangle1.yVertex2 <= rectanglePair.rectangle2.yVertex1) ||(rectanglePair.rectangle1.yVertex1 >= rectanglePair.rectangle2.yVertex2 && rectanglePair.rectangle1.yVertex1 <= rectanglePair.rectangle2.yVertex1)))
            {
                return true;
            }
            //Top alignment
            else if (rectanglePair.rectangle1.yVertex1 == rectanglePair.rectangle2.yVertex2 && ((rectanglePair.rectangle1.xVertex2 >= rectanglePair.rectangle2.xVertex1 && rectanglePair.rectangle1.xVertex2 <= rectanglePair.rectangle2.xVertex2) || (rectanglePair.rectangle1.xVertex1 >= rectanglePair.rectangle2.xVertex1 && rectanglePair.rectangle1.xVertex1 <= rectanglePair.rectangle2.xVertex2)))
            {
                return true;
            }
            //Bottom alignment
            else if (rectanglePair.rectangle1.yVertex2 == rectanglePair.rectangle2.yVertex1 && ((rectanglePair.rectangle1.xVertex2 >= rectanglePair.rectangle2.xVertex1 && rectanglePair.rectangle1.xVertex2 <= rectanglePair.rectangle2.xVertex2) || (rectanglePair.rectangle1.xVertex1 >= rectanglePair.rectangle2.xVertex1 && rectanglePair.rectangle1.xVertex1 <= rectanglePair.rectangle2.xVertex2)))
            {
                return true;
            }
            return false;
        }
        public bool HasContainment(RectanglePair rectanglePair)
        {
            if (rectanglePair.rectangle1.xVertex1 <= rectanglePair.rectangle2.xVertex1 && rectanglePair.rectangle1.yVertex1 >= rectanglePair.rectangle2.yVertex1 && rectanglePair.rectangle1.xVertex2 >= rectanglePair.rectangle2.xVertex2 && rectanglePair.rectangle1.yVertex2 <= rectanglePair.rectangle2.yVertex2)
                return true;

            return false;
        }
    }
}