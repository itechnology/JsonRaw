using System.Collections.Generic;

namespace JsonR.Models
{
    public class JsonR
    {
        public string Type         { get; set; }
        public List<object> Keys   { get; set; }
        public List<object> Values { get; set; }

        public JsonR()
        {
            Keys   = new List<object>();
            Values = new List<object>();
        }
    }
}
