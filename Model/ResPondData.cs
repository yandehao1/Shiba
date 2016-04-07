using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Model
{
    public enum State { ok, err }
    public class ResPondData
    {
        public State State { get; set; }
        public string  Msg { get; set; }
        public object Data { get; set; }
        public string  BackUrl { get; set; }
    }
}
