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

        public RectangleProperties rectangleProperties { get; set; }

        public RectanglePair(Rectangle rect1, Rectangle rect2)
        {
            rectangle1 = StandardizeVertices(rect1);
            rectangle2 = StandardizeVertices(rect2);

            //if Rectangle 1 does not have the left most cooridinate, switch the designation of rectangle 1 and rectangle 2. (this makes logic a lot easier)
            if(rectangle2.xVertex1 < rectangle1.xVertex1)
            {
                var placeholderRectangle = rectangle1;

                rectangle1 = rectangle2;
                rectangle2 = placeholderRectangle;
            }
            //if they're equal, then use the highest y-coordinate as rectangle 1
            else if(rectangle2.xVertex1 == rectangle1.xVertex1 && rectangle2.yVertex1 > rectangle1.yVertex1)
            {
                var placeholderRectanlge = rectangle1;

                rectangle1 = rectangle2;
                rectangle2 = placeholderRectanlge;
            }

        }

        private Rectangle StandardizeVertices(Rectangle rectangle)
        {
            //straight swap them if the bottom right were defined first
            if(rectangle.xVertex1 > rectangle.xVertex2 && rectangle.yVertex1 < rectangle.yVertex2)
            {

                int newX1 = rectangle.xVertex2;
                int newY1 = rectangle.yVertex2;

                rectangle.xVertex2 = rectangle.xVertex1;
                rectangle.yVertex2 = rectangle.yVertex1;

                rectangle.xVertex1 = newX1;
                rectangle.yVertex1 = newY1;
            }
            //flip x and Y coordinates if top right were first
            else if(rectangle.xVertex1 > rectangle.xVertex2 && rectangle.yVertex1 > rectangle.yVertex2)
            {
                int newX1 = rectangle.xVertex2;
                int newY1 = rectangle.yVertex1;

                rectangle.xVertex2 = rectangle.xVertex1;
                rectangle.yVertex2 = rectangle.yVertex2;

                rectangle.xVertex1 = newX1;
                rectangle.yVertex1 = newY1;
            }
            //flip again if bottom left were defined first
            else if(rectangle.xVertex1 < rectangle.xVertex2 && rectangle.yVertex1 < rectangle.yVertex2)
            {
                int newX1 = rectangle.xVertex1;
                int newY1 = rectangle.yVertex2;

                rectangle.xVertex2 = rectangle.xVertex2;
                rectangle.yVertex2 = rectangle.yVertex1;

                rectangle.xVertex1 = newX1;
                rectangle.yVertex1 = newY1;
            }

            return rectangle;
        }

    }

    public class RectangleProperties
    {
        public bool hasIntersection { get; set; }
        public bool hasContainment { get; set; }
        public bool hasAdjacency { get; set; }
    }
}