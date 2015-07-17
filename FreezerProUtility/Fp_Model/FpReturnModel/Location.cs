namespace FreezerProUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string location1 { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string @out { get; set; }
        public string freeze_thaw { get; set; }
        public string position { get; set; }
        public string icon { get; set; }
        public string owner { get; set; }
        public string created_at { get; set; }
    }
}
