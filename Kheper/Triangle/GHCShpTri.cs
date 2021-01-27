using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Kheper
{
    public class GHCShpTri : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ShiTriNewlyCreated class.
        /// </summary>
        public GHCShpTri()
          : base("Sphere_Tetrahedron",
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
            pManager.AddPlaneParameter("Base Plane", "Base Plan", "Base Plan", GH_ParamAccess.item, Plane.WorldXY);
            pManager.AddNumberParameter("Radius", "Radius", "Radius", GH_ParamAccess.item,1);
            pManager.AddBooleanParameter("Mirror", "Mirror", "Mirror", GH_ParamAccess.item,false);
        }


        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

            pManager.AddGeometryParameter("Display Sphere", "Display Sphere", "Display Sphere", GH_ParamAccess.list);
            pManager.AddCurveParameter("Display Circumscribed Tetra", "Display Circumscribed Tetra", "Display Circumscribed Tetra", GH_ParamAccess.list);
            pManager.AddCurveParameter("Display Eql Vol Tetra", "Display Eql Vol Tetra", "Display Eql Vol Tetra", GH_ParamAccess.list);
            pManager.AddCurveParameter("Display Eql Area Tetra", "Display Eql Area Tetra", "Display Eql Area Tetra", GH_ParamAccess.list);

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


            SphTetra ST = new SphTetra(iBasePlane, iRadius, iMirror);

            List<Sphere> sph = ST.ComputeSphere();
            DA.SetDataList("Display Sphere", sph);

            List<Line> ComCirTet = ST.ComputeCircumscribedTetra(); 
            DA.SetDataList("Display Circumscribed Tetra", ComCirTet);


            List<Line> ComEqlVolTet = ST.ComputeEqlVolumTetra();
            DA.SetDataList("Display Eql Vol Tetra", ComEqlVolTet);


            List<Line> ComEqlAreaTet = ST.ComputeEqlAreaTetra();
            DA.SetDataList("Display Eql Area Tetra", ComEqlAreaTet);
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
                //return null;
                return Properties.Resources.Circle_Triangle_02;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("8f1bbb69-0dcf-46ef-b782-4a06ca985294"); }
        }
    }
}