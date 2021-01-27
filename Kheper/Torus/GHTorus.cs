using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;

namespace Kheper
{
    public class GHTorus : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Torus class.
        /// </summary>
        public GHTorus()
          : base("Torus_Basic", "Nickname",
              "Draw basic torus",
              "Kheper", "Torus")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Base Plane", "Base Plan", "Base Plan", GH_ParamAccess.item,Plane.WorldXY);
            pManager.AddNumberParameter("Radius of Main Circle", "ROfMainCir", "Radius of Main Central Circle", GH_ParamAccess.item,1);
            pManager.AddNumberParameter("Radius of Secondary Circle", "ROfSecCir", "Radius of Secondar Circle", GH_ParamAccess.item, 2);
            pManager.AddIntegerParameter("No Of Division", "No Of Division", "No Of Division", GH_ParamAccess.item, 3);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPlaneParameter("Display Planes on C1", "Display Planes on C1", "Display Planes on C1", GH_ParamAccess.list);
            pManager.AddGenericParameter("Display Planes on C2", "Display Planes on C2", "Display Planes on C2", GH_ParamAccess.tree);

            pManager.AddCircleParameter("Display C1", "Display C1", "Display C1", GH_ParamAccess.list);
            pManager.AddCircleParameter("Display C2", "Display C2", "Display C2", GH_ParamAccess.list);


        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            Plane iBasePlane = Plane.WorldXY;
            double iR1 = 1.0;
            double iR2 = 1.0;
            int iNoOfBlades = 3;



            DA.GetData("Base Plane", ref iBasePlane);
            DA.GetData("Radius of Main Circle", ref iR1);
            DA.GetData("Radius of Secondary Circle", ref iR2);
            DA.GetData("No Of Division", ref iNoOfBlades);

            Torus.SimpleTorus SMP = new Torus.SimpleTorus(iBasePlane, iR1, iR2, iNoOfBlades);

            List<Plane> displayPlane = SMP.ComputePlanesOfSingleCircle(iBasePlane,iR1);
            DA.SetDataList("Display Planes on C1", displayPlane);

            DataTree<Plane> DisplaySecondaryPlanes = SMP.SecondaryPlaneConclusion();
            DA.SetDataTree(1, DisplaySecondaryPlanes);

            Circle displayC1 = SMP.Return_C1();
            DA.SetData("Display C1", displayC1);


            List<Circle>  displayC2 = SMP.Return_C2();
            DA.SetDataList("Display C2", displayC2);
            // List<Circle> displayMainCir = SMP.ComputeMainCircles();
            // DA.SetDataList("Display Mother Circle", displayMainCir);


            // List<Point3d> displayMainPoints = SMP.ComputePointsOnMainCircles ();
            //DA.SetDataList("Display Points", displayMainPoints);

            // List<Circle> displayCircs = SMP.CalculateCircleInOneDirection();
            // DA.SetDataList("Display Circles", displayCircs);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                return Properties.Resources.Torus;                
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("9baa4141-dc37-482c-98da-b81ad46e229b"); }
        }
    }
}