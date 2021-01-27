using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
/*
namespace Kheper
{
    public class GhcAverage : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GhcAverage class.
        /// </summary>
        public GhcAverage()
          : base("Average",
                "Average",
              "Compute the average of two numbers",
              "Workshop",
              "Miscellaneous")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("First Number", "First", "the first number", GH_ParamAccess.item, 0.0);
            pManager.AddNumberParameter("Secondss Number", "Second", "the second number", GH_ParamAccess.item, 0.0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Average", "Average", "Average Of Two Number", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double a = Double.NaN;
            double b = Double.NaN;

            DA.GetData(0, ref a);
            DA.GetData(1, ref b);

            double average = 0.5 * (a + b);

            DA.SetData(0, average);


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
            get { return new Guid("60490c7c-e649-4922-b218-e41ef1ad0a3c"); }
        }
    }
}


    */