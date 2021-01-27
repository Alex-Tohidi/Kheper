using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;

namespace Kheper.Torus
{
    public class GH_Complete_Torus : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_Complete_Torus class.
        /// </summary>
        public GH_Complete_Torus()
          : base("GH_Complete_Torus", "CompTorus ",
              "Description",
              "Kheper", "Torus")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Base Plane", "Base Plan", "Base Plan", GH_ParamAccess.item, Plane.WorldXY);
            pManager.AddNumberParameter("Radius of Main Circle", "ROfMainCir", "Radius of Main Central Circle", GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("Radius of Secondary Circle", "ROfSecCir", "Radius of Secondar Circle", GH_ParamAccess.item, 2);
            pManager.AddIntegerParameter("No Of Division", "No Of Division", "No Of Division", GH_ParamAccess.item, 3);
            //
            pManager.AddIntegerParameter("No Of Shift C1", "No Of Shift C1", "No Of Shift C1", GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("No Of Shift C2", "No Of Shift C2", "No Of Shift C2", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {


            pManager.AddCircleParameter("Display C1", "Display C1", "Display C1", GH_ParamAccess.list);

            pManager.AddPlaneParameter("Display Planes on C1", "Display Planes on C1", "Display Planes on C1", GH_ParamAccess.list);



            pManager.AddCircleParameter("Display C2_Vertical", "Display C2_Verti4cal", "Display C2_Vertical", GH_ParamAccess.list);

            pManager.AddGenericParameter("Display Planes on C2", "Display Planes on C2", "Display Planes on C2", GH_ParamAccess.tree);

            pManager.AddCircleParameter("Display C2_Horizontal", "Display C2_Horizontal", "Display C2_Horizontal", GH_ParamAccess.list);



            pManager.AddCurveParameter("Display Shifted Verticale", "Display Shifted Verticale", "Display Shifted Verticale", GH_ParamAccess.list);
            pManager.AddCurveParameter("Display Shifted Horizontal", "Display Shifted Horizontal", "Display Shifted Horizontal", GH_ParamAccess.list);


            /*
            pManager.AddGenericParameter("Display Planes on C2", "Display Planes on C2", "Display Planes on C2", GH_ParamAccess.tree);
            */
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
            int iC1Shift = 0;
            int iC2Shift = 0;



            DA.GetData("Base Plane", ref iBasePlane);
            DA.GetData("Radius of Main Circle", ref iR1);
            DA.GetData("Radius of Secondary Circle", ref iR2);
            DA.GetData("No Of Division", ref iNoOfBlades);
            DA.GetData("No Of Shift C1", ref iC1Shift);
            DA.GetData("No Of Shift C2", ref iC2Shift);


            Torus.CompleteTorus CMP = new Torus.CompleteTorus(iBasePlane, iR1, iR2, iNoOfBlades, iC1Shift, iC2Shift);

            Circle MainC1 = CMP.Return_C1();
            DA.SetData("Display C1", MainC1);

            List<Plane> displayPlane = CMP.Return_C1_Planes();
            DA.SetDataList("Display Planes on C1", displayPlane);



            List<Circle> displayC2 = CMP.Return_C2_Vertical();
            DA.SetDataList("Display C2_Vertical", displayC2);

            DataTree<Plane> displayC2Plane = CMP.Return_C2_Planes();
            DA.SetDataTree(3, displayC2Plane);

            List<Circle> displayC2_Horizontal = CMP.Return_C2_Horizontal();
            DA.SetDataList("Display C2_Horizontal", displayC2_Horizontal);



            List<Curve> displayShiftedVer = CMP.Return_Shifted_Vertical();
            DA.SetDataList("Display Shifted Verticale", displayShiftedVer);

            List<Curve> displayShiftedHor = CMP.Return_Shifted_Horizontal();
            DA.SetDataList("Display Shifted Horizontal", displayShiftedHor);



            //  DataTree<Plane> DisplaySecondaryPlanes = CMP.SecondaryPlaneConclusion();
            //  DA.SetDataTree(1, DisplaySecondaryPlanes);
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
                return Properties.Resources.Shift; ;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("62ea4233-2a9a-45bd-b971-c3ede759f981"); }
        }
    }
}