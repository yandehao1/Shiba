using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Threading;

namespace FreezerProUtility.Fp_Model
{
   public partial class Sample_Out
    {
       public int obj_id { get; set; }
        public string id { get; set; }
        public string sample_type { get; set; }
        public string name { get; set; }
        public string scount { get; set; }
        public string in_vials { get; set; }
        public string out_vials { get; set; }
        public string description { get; set; }
        public string owner { get; set; }
        public int owner_id { get; set; }
        public string created_at { get; set; }
    }
}
