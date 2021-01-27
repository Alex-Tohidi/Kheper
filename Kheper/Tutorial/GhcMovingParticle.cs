using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
/*
namespace Kheper
{
    public class GhcMovingParticle : GH_Component
    {
        Point3d currentPosition;
        /// <summary>
        /// Initializes a new instance of the GhcMovingParticle class.
        /// </summary>
        public GhcMovingParticle()
          : base("GhcMovingParticle", "MovingParticle",
              "Description",
              "Workshop", "Subcategory")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset", GH_ParamAccess.item);
            pManager.AddVectorParameter("Velocity", "Velocity", "Velocity", GH_ParamAccess.item);
        }


        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Particle", "Particle", "Particle", GH_ParamAccess.item);
        }


        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool iReset = false;
            DA.GetData("Reset", ref iReset);
            if (iReset)
                currentPosition = new Point3d(0, 0, 0);
            else
            {
                Vector3d iVelocity = new Vector3d(0, 0, 0);
                DA.GetData("Velocity", ref iVelocity);
                currentPosition += iVelocity;
            }
            DA.SetData("Centroid",  currentPosition);

        }


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
            get { return new Guid("185ec605-e17b-4f95-ab6d-00ce91621924"); }
        }
    }
}

    */