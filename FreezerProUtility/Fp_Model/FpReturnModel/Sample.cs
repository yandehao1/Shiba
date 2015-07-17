namespace FreezerProUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sample
    {
        public string id { get; set; }
        public string sample_type { get; set; }
        public string  scount { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string owner { get; set; }
        public string created_at { get; set; }
    }
}
