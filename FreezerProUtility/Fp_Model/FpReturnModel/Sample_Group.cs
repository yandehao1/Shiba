namespace FreezerProUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sample_Group
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string inuse { get; set; }
        public Nullable<int> vials { get; set; }
        public Nullable<int> volume { get; set; }
        public string created_at { get; set; }
    }
}
