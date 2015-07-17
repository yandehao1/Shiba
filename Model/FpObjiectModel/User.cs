namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string id { get; set; }
        public string uesrname { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string created_at { get; set; }
        public string role { get; set; }
        public Nullable<int> samples { get; set; }
    }
}
