using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthHack.TiSM.Model
{
    public  class MutationPoint
    {
        public int Position { get; set; }
        public string ChangeType { get; set; } //change,add,deletion
        public string From { get; set; }
        public string To { get; set; }
        public string Identifier { get; set; }
        public  MutationPoint(string data)
        {
            Identifier = data;
            int pos = 0;
            char[] find = "ATCGd-+".ToCharArray();
            int endPos = data.IndexOfAny(find, 2);
            int.TryParse(data.Substring(2, endPos - 2), out pos);
            Position = pos;
            System.Diagnostics.Debug.Write(pos +",");
        }
    }
}
