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
    class SimpleTorus
    {

        public Plane BasePlane = Plane.WorldXY;
        public double R1 = 1.0;
        public double R2 = 1.0;
        private double NoOfNodes = 3.0;

        //Helper
        private List<Plane> R1Planes = new List<Plane>();
        private Circle C1 = new Circle();
        private List<Circle> temCirList = new List<Circle>();
        //Helper
        private List<List<Plane>> R2PlanesList = new List<List<Plane>>();

        //Data tree to be returned for secondary
        DataTree<Plane> SecondaryPlanes = new DataTree<Plane>();




            //Constructors

        public SimpleTorus(double r1, double r2, int numberOfNodes)
        {
            R1 = r1;
            R2 = r2;

            // The following line will take care of converstion, difining type Double
            NoOfNodes = Convert.ToDouble(numberOfNodes);
        }

        public SimpleTorus(Plane basePlane, double r1, double r2, int numberOfNodes)
        {
            BasePlane = basePlane;
            R1 = r1;
            R2 = r2;

            // The following line will take care of converstion, difining type Double
            NoOfNodes = Convert.ToDouble(numberOfNodes);
        }






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
                Plane iP = new Plane(cen, -tng , ttt);
                
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



    }
}


