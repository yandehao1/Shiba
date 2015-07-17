namespace FreezerProUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SampleTypes
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public string descr { get; set; }
        public string enable { get; set; }
        public Nullable<int> fields_conut { get; set; }
        public string fields { get; set; }
        public string inuse { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
