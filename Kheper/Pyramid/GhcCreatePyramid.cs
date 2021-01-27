using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;



namespace Kheper
{
    public class GhcCreatePyramid : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GhcCreatePyramid class.
        /// </summary>
        public GhcCreatePyramid()
          : base("GhcCreatePyramid",
                "Pyramid",
              "Description",
              "Kheper", "Pyramid")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Base Plane", "Base Plan", "Base Plan ", GH_ParamAccess.item);
            pManager.AddNumberParameter("Length", "Length", "Length", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "Width", "Width", GH_ParamAccess.item);
            pManager.AddNumberParameter("Height", "Height", "Height", GH_ParamAccess.item);
        }




        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

            pManager.AddCurveParameter("Display Lines", "Display Lines", "Display Lines", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Plane iBasePlane = Plane.WorldXY;
            double iLenght = 1.0;
            double iWidth = 1.0;
            double iHeight = 1.0;


            DA.GetData("Base Plane", ref iBasePlane);
            DA.GetData("Length", ref iLenght);
            DA.GetData("Width", ref iWidth);
            DA.GetData("Height", ref iHeight);


            Pyramid myPyramid = new Pyramid(iBasePlane, iLenght, iHeight, iWidth);
            List<LineCurve> displayLines = myPyramid.ComputeDisplayLines();
            DA.SetDataList("Display Lines", displayLines);


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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("2ca5e051-2e08-40ef-9af1-b54a82d3832a"); }
        }
    }
}