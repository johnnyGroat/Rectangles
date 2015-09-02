# Rectangles

#Objective
To figure out if a set of rectangles are intersecting, contained, adjacent, or any combination of the previous

#Assumptions
There were no explicit instructions as to how a user inputs each rectangle’s vertices.  A web interface will be used for the user to input X and Y integer values for the vertex of each square’s corner.  

#Implementation
The solution will be made using Microsoft .NET and an MVC framework to organize the code. This will be implemented as a single webpage.

#Limitations
Each rectangle pair needs to be defined on a grid from 0-300 units (my own imposed restriction to provide adequate functionality while limiting user possibilities) on both X and Y coordinates.

There is no current input check for this program, so any non-integer value will cause this program to throw an error.

#Additional Libraries
JSON.NET (http://www.newtonsoft.com/json)
this easily throws the ajax data into the Rectangles Object

#Output
The outupt for this project is web based.  There is an HTML canvas element that will draw the two rectangles as outlined and will output which (if any) of the 3 criteria have been satisfied.
