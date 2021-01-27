using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;



namespace Kheper
{
    class SphTetra

    {
        public Plane BasePlane = Plane.WorldXY;
        public double Radius = 1.0;
        public Boolean Mirror = false;


        public double Sides = 3;




        public SphTetra(double r)
        {
            Radius = r;

        }



        public SphTetra(Plane basePlane, double r, Boolean Mirr)
        {
            Radius = r;
            BasePlane = basePlane;
            Mirror = Mirr;
        }


        public List<Sphere> ComputeSphere()
        {
            Sphere C = new Sphere (BasePlane, Radius);



            // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
            //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;

            // List<LineCurve> displayLines = new List<LineCurve>();
            List<Sphere> Only_Sphere = new List<Sphere>();



            // displayLines.Add(new LineCurve(A, B));
            Only_Sphere.Add(C);

            
            return Only_Sphere;
        }



        public List<Line> ComputeCircumscribedTetra()
        {
            //?????????????????????????????????????????????????????
            //??????????????
            //??
            double ir = 2 * Radius;
            return ComputeTetra(ir,Mirror);

        }

        public List<Line> ComputeEqlVolumTetra()
        {
            //?????????????????????????????????????????????????????
            //??????????????
            //??

            double ir =  Radius;
            double VolumSphere = (4 / 3) * Math.PI * Math.Pow(ir, 3);

            //Volum tetrahedron  a^3/(6*(2^0.5))
            double VolumTetra = VolumSphere;
            double a = Math.Pow(((VolumTetra * 6)* (Math.Sqrt(2))),(1/3.0));

            return ComputeTetra(a, Mirror);

        }


        public List<Line> ComputeEqlAreaTetra()
        {
            //?????????????????????????????????????????????????????
            //??????????????
            //??

            double ir = Radius;
            double AreaSphere = 4 * Math.PI * Math.Pow(ir, 2);

            //Volum tetrahedron  a^3/(6*(2^0.5))
            double AreaTetra = AreaSphere;
            double a = Math.Sqrt(AreaTetra / (Math.Sqrt(3)));

            return ComputeTetra(a, Mirror);

        }

        public List <Line> ComputeTetra(Double a ,Boolean Mir)
        {
            //utilising a oposite corners of the cube to draw tetraherdon
            // based on pythagorean theorem: 
            //Lenght of the cube is :   
            // CubeLenght = LEnght of tetra/(2^0.5)

            double LenghtOfCube = a / Math.Sqrt(2);

            //Draw cube
            //Have to utilise Bounding box

            BoundingBox Helper1 = new BoundingBox(-LenghtOfCube / 2, -LenghtOfCube / 2, -LenghtOfCube / 2, LenghtOfCube / 2, LenghtOfCube / 2, LenghtOfCube / 2);


            //Define a box to set to the plane

            Box Helper2 = new Box(BasePlane, Helper1);

            Point3d[] Corners =  Helper2.GetCorners();

            List<Line> Tetra = new List<Line>();

            Tetra.Add(new Line(Corners[0], Corners[2]));
            Tetra.Add(new Line(Corners[5], Corners[7]));

            Tetra.Add(new Line(Corners[0], Corners[5]));
            Tetra.Add(new Line(Corners[0], Corners[7]));


            Tetra.Add(new Line(Corners[2], Corners[5]));
            Tetra.Add(new Line(Corners[2], Corners[7]));

            if (Mir == true)
                //Draw Mirrored Tetrahedron
            {
                Tetra.Add(new Line(Corners[1], Corners[3]));
                Tetra.Add(new Line(Corners[4], Corners[6]));

                Tetra.Add(new Line(Corners[1], Corners[4]));
                Tetra.Add(new Line(Corners[1], Corners[6]));


                Tetra.Add(new Line(Corners[3], Corners[4]));
                Tetra.Add(new Line(Corners[3], Corners[6]));
            }

            

            return Tetra;


        }

        /*
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


                public List<Point3d>  ComputeCentroid ()
                {

                    Circle CT = new Circle(BasePlane, Radius);
                    Point3d Nine = new Point3d(CT.PointAt((0) * Math.PI * 2));
                    Point3d Three = new Point3d(CT.PointAt((1.0 / 3.0) * Math.PI * 2));
                    Point3d Six = new Point3d(CT.PointAt((2.0 / 3.0) * Math.PI * 2));


                    // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
                    // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
                    //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;



                    List<Point3d> iCenteroid = new  List<Point3d>();
                    iCenteroid.Add(Nine);
                    iCenteroid.Add(Three);
                    iCenteroid.Add(Six);

                    Centroid Centre = new Centroid(BasePlane, iCenteroid);
                    return Centre.ComCentroid(iCenteroid);
                    //List<Line> Only_Tri = new List<Line>();


                    //Only_Tri.Add(new Line(Nine, Three));
                    //Only_Tri.Add(new Line(Three, Six));
                   // Only_Tri.Add(new Line(Six, Nine));

                }
                public List<double> ComputeDisCentroid()
                {

                    Circle CT = new Circle(BasePlane, Radius);
                    Point3d Nine = new Point3d(CT.PointAt((0) * Math.PI * 2));
                    Point3d Three = new Point3d(CT.PointAt((1.0 / 3.0) * Math.PI * 2));
                    Point3d Six = new Point3d(CT.PointAt((2.0 / 3.0) * Math.PI * 2));


                    // Point3d A_Nneine = BasePlane.Origin + BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
                    // Point3d B = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 + BasePlane.YAxis * Width * 0.5;
                    //Point3d C = BasePlane.Origin - BasePlane.XAxis * Length * 0.5 - BasePlane.YAxis * Width * 0.5;



                    List<Point3d> iCenteroid = new List<Point3d>();
                    iCenteroid.Add(Nine);
                    iCenteroid.Add(Three);
                    iCenteroid.Add(Six);

                    Centroid Centre = new Centroid(BasePlane, iCenteroid);
                    return Centre.ComputeDistancesToCentroid(iCenteroid);
                    //List<Line> Only_Tri = new List<Line>();


                    //Only_Tri.Add(new Line(Nine, Three));
                    //Only_Tri.Add(new Line(Three, Six));
                    // Only_Tri.Add(new Line(Six, Nine));

                }*/
    }
}
