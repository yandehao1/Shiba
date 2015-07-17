using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_Common
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class HelpAttribute : Attribute
    {
        public HelpAttribute(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;
            }
        }
    }
}
