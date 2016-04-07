namespace FpUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserFields
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public string type { get; set; }
        public string values { get; set; }
        public Nullable<int> inuse { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
