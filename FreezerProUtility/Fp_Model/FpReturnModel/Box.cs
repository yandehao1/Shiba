namespace FreezerProUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Box
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> width { get; set; }
        public Nullable<int> height { get; set; }
        public string samples { get; set; }
        public string user { get; set; }
        public string box_type_id { get; set; }
        public string free_cells { get; set; }
    }
}
