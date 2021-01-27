using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

namespace Kheper.Torus
{
    class CompleteTorus
    {

        public Plane BasePlane = Plane.WorldXY;
        public double R1 = 1.0;
        public double R2 = 1.0;

        //Private , data type conversaion was required for furthur aregmatic 
        private double NoOfNodes = 3.0;

        //Private , data type conversaion was required for furthur aregmatic 
        private int NoOfShiftC1 = 0;
        private int NoOfShiftC2 = 0;
        private double JainPi = 3.144605511029693144;



        //The followings are difined with-in the class 
        // only return through a function.
        //Therefore Private
        private Circle C1 = new Circle(Plane.WorldXY,1);
        private List<Plane> PlanesOnC1 = new List<Plane>();

        private List<Circle> C2_Ver = new List<Circle>(); // (Plane.WorldXY, 1);
        //private List<List<Plane>> C2PlanesList = new List<List<Plane>>();
        private List<List<Plane>> C2PlanesList = new List<List<Plane>>();


        private List<Circle> C2_Hor = new List<Circle>();

        /*
        //Helper
        private List<Plane> R1Planes = new List<Plane>();
        private Circle C1 = new Circle();
        private List<Circle> temCirList = new List<Circle>();
        //Helper
        private List<List<Plane>> R2PlanesList = new List<List<Plane>>();

        //Data tree to be returned for secondary
        DataTree<Plane> SecondaryPlanes = new DataTree<Plane>();
        */



        //Constructors

        public CompleteTorus(Plane basePlane, double r1, double r2, int numberOfNodes, int noOfShiftC1, int noOfShiftC2)
        {
            BasePlane = basePlane;
            R1 = r1;
            R2 = r2;

            // The following line will take care of converstion, difining type Double
            NoOfNodes = Convert.ToDouble(numberOfNodes);

            NoOfShiftC1 = noOfShiftC1;
            NoOfShiftC2 = noOfShiftC2;

        }




        //Setting the methods
        //Return C1 Circle
        public Circle Return_C1()
        {
            C1 = new Circle(BasePlane, R1);
            return C1;
        }


        public List<Plane> Return_C1_Planes()
        {
            PlanesOnC1 = ComputePlanesOfSingleCircle(C1);
            return PlanesOnC1;
        }


        public List<Circle> Return_C2_Vertical()
        {
            List<Plane> temPlanes = new List<Plane>();
            foreach (Plane p in PlanesOnC1)
            {

                Circle temCir = new Circle(p, R2);
                C2_Ver.Add(temCir);


                //also adding planes
                //For performance purpose

                temPlanes = ComputePlanesOfSingleCircle(temCir);
                C2PlanesList.Add(temPlanes);


            }
               
            return C2_Ver;
        }




        public List<Curve> Return_Shifted_Vertical()
        {
            
            List<Plane> temPlanes = new List<Plane>();
            List<Curve> outputCurve = new List<Curve>();
            

            List<List<Point3d>> PointsOfAllThePaths = new List<List<Point3d>>();
            // List<Point3d> PointsOfSinglePath = new List<Point3d>();

            for (int Row = 0; Row < NoOfNodes; Row++)

            {
                List<Point3d> PointsOfSinglePath = new List<Point3d>();

                for (int Col = 0; Col < NoOfNodes; Col++)
                {

                    //temPlanes = C2PlanesList[((Row * NoOfShiftC1) % Convert.ToInt16(NoOfNodes))];

                    //Plane pp = temPlanes[Row];
                   // Plane TemP = C2PlanesList[(Col + (Row * NoOfShiftC1)) % Convert.ToInt32(NoOfNodes)][Col];


                    Plane TemP = C2PlanesList[(Row + (Col * NoOfShiftC1)) % Convert.ToInt32(NoOfNodes)][Col];
                    PointsOfSinglePath.Add(TemP.Origin);


                }

                //Plane EndP = C2PlanesList[(0 + (Row * NoOfShiftC1)) % Convert.ToInt32(NoOfNodes)][0];
                Point3d end = PointsOfSinglePath[0];
                PointsOfSinglePath.Add(end);

                if (NoOfShiftC1 != 0)
                {
                    Curve cur = InterpolatePoints(PointsOfSinglePath);
                    cur.MakeClosed(0);
                    Curve cur_V1 = Curve.CreatePeriodicCurve(cur);
                    outputCurve.Add(cur_V1);
                }
                
            }
   

            return outputCurve;
        }



        //Not Completed
        public List<Curve> Return_Shifted_Horizontal()
        {

            List<Plane> temPlanes_H = new List<Plane>();
            List<Curve> outputCurve_H = new List<Curve>();


            List<List<Point3d>> PointsOfAllThePaths_H = new List<List<Point3d>>();
            // List<Point3d> PointsOfSinglePath = new List<Point3d>();
            for (int Col = 0; Col < NoOfNodes; Col++)
                

            {
                List<Point3d> PointsOfSinglePath_H = new List<Point3d>();


                for (int Row = 0; Row < NoOfNodes; Row++)
                {

                    //temPlanes = C2PlanesList[((Row * NoOfShiftC1) % Convert.ToInt16(NoOfNodes))];

                    //Plane pp = temPlanes[Row];
                    // Plane TemP = C2PlanesList[(Col + (Row * NoOfShiftC1)) % Convert.ToInt32(NoOfNodes)][Col];


                    Plane TemP_H = C2PlanesList[Row][(Col + (Row * NoOfShiftC2)) % Convert.ToInt32(NoOfNodes)];
                    PointsOfSinglePath_H.Add(TemP_H.Origin);


                }

                //Plane EndP = C2PlanesList[(0 + (Row * NoOfShiftC1)) % Convert.ToInt32(NoOfNodes)][0];
                Point3d end = PointsOfSinglePath_H[0];
                PointsOfSinglePath_H.Add(end);

                if (NoOfShiftC2 != 0)
                {
                    Curve cur_H = InterpolatePoints(PointsOfSinglePath_H);
                    cur_H.MakeClosed(0);
                    Curve cur_H1 = Curve.CreatePeriodicCurve(cur_H);
                    outputCurve_H.Add(cur_H1);
                }

            }


            return outputCurve_H;
        }
        Curve InterpolatePoints(IEnumerable<Point3d> pointSeq)
        {
            return Curve.CreateInterpolatedCurve(pointSeq, 3);
        }



        public List<Circle> Return_C2_Horizontal()
        {

            List<Plane> itt = new List<Plane>();
            List<Circle> cir = new List<Circle>();


   

            int i = 0;

            foreach (Plane p in C2PlanesList[0])
            {
                C2_Hor.Add(new Circle(C2PlanesList[0][i].Origin, C2PlanesList[1][i].Origin, C2PlanesList[2][i].Origin));
                i++;
            }


            return C2_Hor;
        }

/*
        public static Curve CreateInterpolatedCurve(
            IEnumerable<Point3d> points,
            int degree,
            CurveKnotStyle knots
        )
        */
        public DataTree<Plane> Return_C2_Planes()
        {
            

            //return SecondaryPlanes;

            return ListOfListsToTree(C2PlanesList);
        }

        /*


                public List<Plane> Return_C1_Planes()
                {

        /*
                public List<Plane> Return_C1_Planes()
                {
                    //  Calculate number of Planes for a single circle
                    //This will return list of Planes




                    // Find the unit of increment on a circle to achive specific number of points ona circle
                    // "2 * Math.PI" refers to a full Circle
                    //True value of Pi to be implemented
                    // double Tt = (1.0 / NoOfNodes) * 2 * Math.PI;
                    double Tt = (1.0 / NoOfNodes) * 2 * JainPi;
                    //Itterate through parameters and calculte planes
                    for (double j = 0; j < 2 * JainPi; j = j + Tt)

                    {


                        //Calculate first drivate
                        //Do not change unless you know what you are doing.
                        int firstdrivative = 0;

                        //Calculate tng
                        Vector3d tng = C1.DerivativeAt(firstdrivative, j);


                        //Points on the R1
                        Point3d cen = C1.PointAt(j);


                        //Calculate a vector to the point from basepoint
                        //Vector3d direction_V = new Vector3d(Vector3d.;
                        Vector3d ttt = BasePlane.Normal;


                        //Calculate Plane
                        Plane iP = new Plane(cen, tng, ttt);

                        PlanesOnC1.Add(iP);



                    }

                    return  PlanesOnC1;

                }







                //To construct a tree from List of Lists
                //Not Sure about following code??!!!
                public DataTree<object> ConstructTreeFromListOfLists(List<List<object>> ListOfObjects)
                {
                    DataTree<object> ConstructedDataTree = new DataTree<object>();

                    int i = 0;
                    foreach (List<object> innerList in ListOfObjects)
                    {
                        ConstructedDataTree.AddRange(innerList, new GH_Path(new int[] { 0, i }));
                        i++;
                    }

                    return ConstructedDataTree;
                }




                /*

                //To Compute Planes Of Single Circle, which is based on given plane
                private List<Plane> ComputePlanesOfSingleCircle(Plane GenericBasePlane, double radiusOfSingleCircle)
                {
                    //  Calculate number of Planes for a single circle
                    //This will return list of Planes
                    List<Plane> Planes = new List<Plane>();


                    Circle C = new Circle(GenericBasePlane, radiusOfSingleCircle);

                    // Find the unit of increment on a circle to achive specific number of points ona circle
                    // "2 * Math.PI" refers to a full Circle
                    //True value of Pi to be implemented
                    double Tt = (1.0 / NoOfNodes) * 2 * Math.PI;

                    //Itterate through parameters and calculte planes
                    for (double j = 0; j < 2 * Math.PI; j = j + Tt)

                    {


                        //Calculate first drivate
                        //Do not change unless you know what you are doing.
                        int firstdrivative = 0;

                        //Calculate tng
                        Vector3d tng = C.DerivativeAt(firstdrivative, j);


                        //Points on the R1
                        Point3d cen = C.PointAt(j);


                        //Calculate a vector to the point from basepoint
                        //Vector3d direction_V = new Vector3d(Vector3d.;
                        Vector3d ttt = basePlane.Normal;
                        //Calculate Plane
                        Plane iP = new Plane(cen, tng, ttt);

                        Planes.Add(iP);



                    }

                    R1Planes = Planes;
                    return R1Planes;
                }


                /*
                        //To Compute Planes Of Single Circle, which is based on given plane
                        public List<Plane> ComputePlanesOfSingleCircle (Plane basePlane, double radiusOfSingleCircle)
                        {
                            //  Calculate number of Planes for a single circle
                            //This will return list of Planes
                            List<Plane> Planes = new List<Plane>();


                            Circle C = new Circle(basePlane, radiusOfSingleCircle);

                            // Find the unit of increment on a circle to achive specific number of points ona circle
                            // "2 * Math.PI" refers to a full Circle
                            //True value of Pi to be implemented
                            double Tt = (1.0 / NoOfNodes) * 2 * Math.PI;

                            //Itterate through parameters and calculte planes
                            for (double j = 0; j < 2 * Math.PI; j = j + Tt)

                            {


                                //Calculate first drivate
                                //Do not change unless you know what you are doing.
                                int firstdrivative = 0;

                                //Calculate tng
                                Vector3d tng = C.DerivativeAt(firstdrivative, j);


                                //Points on the R1
                                Point3d cen = C.PointAt(j);


                                //Calculate a vector to the point from basepoint
                                //Vector3d direction_V = new Vector3d(Vector3d.;
                                Vector3d ttt = basePlane.Normal;
                                //Calculate Plane
                                Plane iP = new Plane(cen, tng , ttt);

                                Planes.Add(iP);



                            }

                            R1Planes = Planes;
                            return R1Planes;
                        }


                        //To construct a tree from List of Lists
                        //Not Sure about following code??!!!
                        private DataTree<Plane> ConstructTreeFromListOfLists (List<List<Plane>> PtC1)
                        {
                            int i = 0;
                            foreach (List<Plane> innerList in PtC1)
                            {
                                SecondaryPlanes.AddRange(innerList, new GH_Path(new int[] { 0, i }));
                                i++;
                            }

                            return SecondaryPlanes;
                        }


                        // To actually implement geometrial rules
                        private List<List<Plane>> CalculateListOfLists(List<Plane> PtC1, double radiusOfSecondCircles)
                        {
                            int i = 0;
                            foreach (Plane innerList in PtC1)
                            {
                                //SecondaryPlanes
                                // SecondaryPlanes.AddRange(innerList, new GH_Path(new int[] { 0, i }));
                           List<Plane> tem = new List<Plane>();

                                    tem = ComputePlanesOfSingleCircle(PtC1[i], radiusOfSecondCircles).ToList();
                                    R2PlanesList.Add(tem);

                                //Create A C2Cirle
                                Circle temCir = new Circle(PtC1[i], radiusOfSecondCircles);
                                //Add C2 circle to the list
                                temCirList.Add(temCir);
                                i++;
                            }

                            //return SecondaryPlanes;

                            return R2PlanesList;
                        }







                        public DataTree<Plane> SecondaryPlaneConclusion  ()
                        {
                            DataTree<Plane> tem = new DataTree<Plane>();

                            List<Plane> C1Pt = ComputePlanesOfSingleCircle(BasePlane, R1);
                            List<List<Plane>> C2Pt = CalculateListOfLists(C1Pt,R2);

                            tem = ConstructTreeFromListOfLists(C2Pt);
                           // List<List<Plane>> tt = CalculateListOfLists(R2PlanesList,R2);

                            return tem;
                        }






                        DataTree<T> ListOfListsToTree<T>(List<List<T>> list)
                        {
                            DataTree<T> tree = new DataTree<T>();
                            int i = 0;
                            foreach (List<T> innerList in list)
                            {
                                tree.AddRange(innerList, new GH_Path(new int[] { 0, i }));
                                i++;
                            }
                            return tree;
                        }



                        //Return C1 Circle
                        public Circle Return_C1 ()
                        {
                            C1 = new Circle(BasePlane, R1);
                            return C1;
                        }

                        //Return C2 Circles
                        public List<Circle> Return_C2()
                        {
                            return temCirList;
                        }
                        */





        //To Compute Planes Of Single Circle, which is based on given plane
        public List<Plane> ComputePlanesOfSingleCircle(Circle CGeneric)
        {
            //  Calculate number of Planes for a single circle
            //This will return list of Planes
            List<Plane> Planes = new List<Plane>();


            Circle C = CGeneric;

            // Find the unit of increment on a circle to achive specific number of points ona circle
            // "2 * Math.PI" refers to a full Circle
            //True value of Pi to be implemented
            double Tt = (1.0 / NoOfNodes) * 2 * Math.PI;

            //Itterate through parameters and calculte planes
            for (double j = 0; j < 2 * Math.PI; j = j + Tt)

            {


                //Calculate first drivate
                //Do not change unless you know what you are doing.
                int firstdrivative = 0;

                //Calculate tng
                Vector3d tng = C.DerivativeAt(firstdrivative, j);


                //Points on the R1
                Point3d cen = C.PointAt(j);


                //Calculate a vector to the point from basepoint
                //Vector3d direction_V = new Vector3d(Vector3d.;
                Vector3d ttt = C.Normal;// BP.Normal;
                //Calculate Plane
                Plane iP = new Plane(cen, -tng, ttt);

                Planes.Add(iP);

            }

            return Planes;
        }






        DataTree<T> ListOfListsToTree<T>(List<List<T>> list)
        {
            DataTree<T> tree = new DataTree<T>();
            int i = 0;
            foreach (List<T> innerList in list)
            {
                tree.AddRange(innerList, new GH_Path(new int[] { 0, i }));
                i++;
            }
            return tree;
        }


    }
}


