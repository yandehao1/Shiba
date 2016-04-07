namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BoxType
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string name { get; set; }
        public Nullable<int> width { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> coords { get; set; }
        public Nullable<int> inuse { get; set; }
    }
}
