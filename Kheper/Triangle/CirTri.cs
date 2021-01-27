using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;



namespace Kheper
{
    class CirTri
    {
        public Plane BasePlane = Plane.WorldXY;
        public double Radius = 1.0;
        public double Sides = 3;
        public Boolean Mirror = false;




        public CirTri(double r)
        {
            Radius = r;
            
        }
        


        public CirTri(Plane basePlane, double r, Boolean Mirr)
        {
            Radius = r;
            BasePlane = basePlane;
            Mirror = Mirr;
        }


        public List<Circle> ComputeCircles()
        {
            Circle C = new Circle(BasePlane, Radius);



            // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;

            // List<LineCurve> displayLines = new List<LineCurve>();
            List<Circle> Only_Circe = new List<Circle>();


  
            // displayLines.Add(new LineCurve(A, B));
            Only_Circe.Add(C);



            return Only_Circe;
        }



        public List<Line> ComputeTriangles()
        {

            Circle CT = new Circle(BasePlane, Radius);
            Point3d Nine = new Point3d(CT.PointAt((0) * Math.PI *2));
            Point3d Three = new Point3d(CT.PointAt((1.0 / 3.0) * Math.PI*2));
            Point3d Six = new Point3d(CT.PointAt((2.0 / 3.0) * Math.PI*2));



            // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;

            // List<LineCurve> displayLines = new List<LineCurve>();
 


            List<Line> Only_Tri = new List<Line>();


            Only_Tri.Add(new Line(Nine, Three));
            Only_Tri.Add(new Line(Three, Six));
            Only_Tri.Add(new Line(Six, Nine));

            


            return Only_Tri;
        }



        public List<Line> ComputeTrianglesEqualCircum()
        {

            Circle CT = new Circle(BasePlane, Radius);



            double pr = CT.Circumference;
            double NewtriSides = pr / 3;


            double NewR = NewtriSides / Math.Pow(3.0, 0.5); 


            Circle CTF = new Circle(BasePlane, NewR);



            
            Point3d Nine = new Point3d(CTF.PointAt((0) * Math.PI * 2));
            Point3d Three = new Point3d(CTF.PointAt((1.0 / 3.0) * Math.PI * 2));
            Point3d Six = new Point3d(CTF.PointAt((2.0 / 3.0) * Math.PI * 2));


            // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;

            // List<LineCurve> displayLines = new List<LineCurve>();



            List<Line> Only_Tri = new List<Line>();


            Only_Tri.Add(new Line(Nine, Three));
            Only_Tri.Add(new Line(Three, Six));
            Only_Tri.Add(new Line(Six, Nine));

            return Only_Tri;
        }


        public List<Line> ComputeTrianglesEqualArea()
        {

            Circle CT = new Circle(BasePlane, Radius);




            double rNew = Math.Sqrt(((Math.PI) * 1/(0.5 * Math.Sqrt(3.0) * 3 * 0.5))*Radius * Radius);

           


            Circle CTF = new Circle(BasePlane, rNew);




            Point3d Nine = new Point3d(CTF.PointAt((0) * Math.PI * 2));
            Point3d Three = new Point3d(CTF.PointAt((1.0 / 3.0) * Math.PI * 2));
            Point3d Six = new Point3d(CTF.PointAt((2.0 / 3.0) * Math.PI * 2));


            // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;

            // List<LineCurve> displayLines = new List<LineCurve>();



            List<Line> Only_Tri = new List<Line>();


            Only_Tri.Add(new Line(Nine, Three));
            Only_Tri.Add(new Line(Three, Six));
            Only_Tri.Add(new Line(Six, Nine));

            return Only_Tri;
        }
    }
}
