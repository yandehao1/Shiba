using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_Model.Fp_Method
{
  public  class ReturnedStatus
    {
        //{"status":"DONE","msg":"NNN Records successfully updated.","success":true}
        public string  status { get; set; }
        public string msg { get; set; }
        public bool success { get; set; }
    }
}
