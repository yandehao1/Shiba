using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Threading;

namespace FpUtility.Fp_Model
{
    public class Sample_Info
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string sample_type { get; set; }
        public string source { get; set; }
        public string source_id { get; set; }
        public string[] group_ids { get; set; }
        public string scount { get; set; }
        public string volume { get; set; }
        public string volume_in_freezers { get; set; }
        public string owner { get; set; }
        public string expiration { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string location { get; set; }

    }
}
