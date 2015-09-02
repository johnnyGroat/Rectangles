using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rectangles.Models
{
    public class Rectangle
    {
        public int xVertex1 { get; set; }
        public int yVertex1 { get; set; }

        public int xVertex2 { get; set; }
        public int yVertex2 { get; set; }        
    }

    public class RectanglePair
    {
        public Rectangle rectangle1 { get; private set; }
        public Rectangle rectangle2 { get; private set; }

        public List<RectangleProperties> rectangleProperties { get; set; }

        public RectanglePair(Rectangle rect1, Rectangle rect2)
        {
            rectangle1 = rect1;
            rectangle2 = rect2;
        }


    }

    public enum RectangleProperties
    {
        Intersection = 0,
        Containment,
        Adjacency
    }
}