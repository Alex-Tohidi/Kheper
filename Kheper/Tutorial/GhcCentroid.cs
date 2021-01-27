using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
/*
namespace Kheper
{
    public class GhcCentroid : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GhcCentroid class.
        /// </summary>
        public GhcCentroid()
          : base("Centroid",
                "Centroid",
              "Centroid of set of Points-001",
              "Workshop",
              "Miscellaneous")
        {

        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "Points", "Points", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Centroid", "Centroid", "Centroid", GH_ParamAccess.item);
            pManager.AddPointParameter("Distance", "Distance", "Distance", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Point3d> iPoints = new List<Point3d>();
            DA.GetDataList("Points", iPoints);

            Point3d centroid = new Point3d(0.0,0.0,0.0);

            foreach (Point3d point in iPoints)
                centroid += point;
            centroid = centroid / iPoints.Count;
            DA.SetData("Centroid", centroid);
            //List<double> distance = new List<double>();

            List<double> distances = new List<double>();
            foreach (Point3d point in iPoints)

                distances.Add(centroid.DistanceTo(point));
            DA.SetData("Distance", distances);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;

                // return Properties.Resources.Circle_Triangle;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("858b7f6f-4180-4622-9034-59b829d75139"); }
        }
    }
}

    */