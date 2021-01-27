using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Kheper
{
    public class GhcCirTri : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Circle_Triangle class.
        /// </summary>
        public GhcCirTri()
          : base("Circle_Triangle",
                "Nickname",
              "Description",
              "Kheper", "Triangle")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Base Plane", "Base Plan", "Base Plan", GH_ParamAccess.item);
            pManager.AddNumberParameter("Radius", "Radius", "Radius", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Mirror", "Mirror", "Mirror", GH_ParamAccess.item, false);
        }




        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCircleParameter("Display Circle", "Display Circle", "Display Circle", GH_ParamAccess.list);

            pManager.AddCurveParameter("Display Tri" , "Display Tri", "Display Tri", GH_ParamAccess.list);

            pManager.AddCurveParameter("Display  Eql Circum", "Display  Eql Circum", "Display  Eql Circum", GH_ParamAccess.list);

            pManager.AddCurveParameter("Display  Eql Area", "Display  Eql Area", "Display  Eql Area", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Plane iBasePlane = Plane.WorldXY;
            double iRadius = 1.0;
            bool iMirror = false;



            DA.GetData("Base Plane", ref iBasePlane);
            DA.GetData("Radius", ref iRadius);
            DA.GetData("Mirror", ref iMirror);

            CirTri CT = new CirTri(iBasePlane, iRadius,iMirror);

            //List<LineCurve> displayLines = CT.ComputeCircles();
            List<Circle> displayCirles = CT.ComputeCircles();
            DA.SetDataList("Display Circle", displayCirles);

           List<Line> displayTri = CT.ComputeTriangles();
           DA.SetDataList("Display Tri", displayTri);


            List<Line> displayTrii = CT.ComputeTrianglesEqualCircum();
            DA.SetDataList("Display  Eql Circum", displayTrii);


            List<Line> displayTriii = CT.ComputeTrianglesEqualArea();
            DA.SetDataList("Display  Eql Area", displayTriii);

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

                return Properties.Resources.Circle_Triangle_02;
                
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("e6ccabc8-d0fe-40cf-90b9-cb61c7810a49"); }
        }
    }
}