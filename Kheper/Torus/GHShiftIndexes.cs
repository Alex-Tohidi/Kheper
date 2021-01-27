using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;

/*
namespace Kheper.Torus
{
    public class GHShiftIndexes : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ShiftIndexes class.
        /// </summary>
        public GHShiftIndexes()
          : base("ShiftIndexes", "Nickname",
                            "Shift torus nodes",
             "Kheper", "Torus")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            //pManager.AddPlaneParameter("Torus C2 Pts", "Torus C2 Pts", "Torus C2 Pts, use simple torus component", GH_ParamAccess.tree);
            pManager.AddGeometryParameter("Torus C2 Pts", "Torus C2 Pts", "Torus C2 Pts, use simple torus component", GH_ParamAccess.tree);
 
            pManager.AddNumberParameter("Number of Shifted Indices", "Number of Shifted Indices", "Number of Shifted Indices", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Shifted Planes", "Shifted Planes", "Shifted Planes", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        { 
            DataTree<Plane> iInputTree = new DataTree<Plane>();
            
            int iNoOfShifts = 0;
            //Plane p = new Plane();
            DA.GetData(1,  ref iInputTree);
          //  DA.GetData("Torus C2 Pts", ref iInputTree);
            DA.GetData("Number of Shifted Indices", ref iNoOfShifts);

            Torus.ShiftIndexes SHI = new Torus.ShiftIndexes(iInputTree, iNoOfShifts);



            int tt = SHI.countItems();
           DA.SetData("Shifted Planes", tt);

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
            get { return new Guid("f740ac4b-4a07-4c48-a824-c63c8f4966e7"); }
        }
    }
}





    */