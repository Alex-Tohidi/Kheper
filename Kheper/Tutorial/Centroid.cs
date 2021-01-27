using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
/*
namespace Kheper
{
    public class Centroid
    {

        public Plane BasePlane = Plane.WorldXY;
        private Point3d O_centroid = new Point3d(0.0, 0.0, 0.0);


        private List<double> distance = new List<double>();
        private List<Point3d> iPoints = new List<Point3d>();
        private List<Point3d> iCentroids = new List<Point3d>();


        public Centroid(Plane basePlane, List<Point3d> Points)
            {

            iPoints = Points;
            BasePlane = basePlane;
            iCentroids = ComCentroid(Points);
            distance = ComputeDistancesToCentroid(Points);
            O_centroid = BasePlane.Origin;

        }




    public List<Point3d > ComCentroid(List<Point3d> Points)
        {
           
            
   
            Point3d centroid1 = new Point3d(0.0, 0.0, 0.0);

            foreach (Point3d point in iPoints)
                centroid1 += point;
            centroid1 = centroid1 / iPoints.Count;
     if (iCentroids.Contains(centroid1))
       { }
   else 
                {
             iCentroids.Add(centroid1); }
            O_centroid = centroid1;
            return iCentroids;
            //List<double> distance = new List<double>();

          //  List<double> distances = new List<double>();
           // foreach (Point3d point in iPoints)

             //   distances.Add(centroid.DistanceTo(point));
            //DA.SetData("Distance", distances);
        }






        public List<double> ComputeDistancesToCentroid(List<Point3d> Points)
        {
           
            

            //Point3d centroid = new Point3d(0.0, 0.0, 0.0);

           
           // List<Point3d> ListCentroid = new List<Point3d>();
            
            

            foreach (Point3d point in Points)
                 distance.Add(point.DistanceTo(O_centroid));
                //DA.SetData("Distance", distances);
                
                return distance;
        }

       
    }
}
*/