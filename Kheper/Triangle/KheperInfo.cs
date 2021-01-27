using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Kheper
{
    public class ComeBackInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Kheper";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("9c548fa1-c652-4eaf-93ad-7242cb5a0d61");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
