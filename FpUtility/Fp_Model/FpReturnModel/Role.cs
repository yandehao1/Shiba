namespace FpUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public string id { get; set; }
        public string name { get; set; }
        public string rights { get; set; }
        public string no_access { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
        public Nullable<int> inuse { get; set; }
        public string systen_role { get; set; }
    }
}
