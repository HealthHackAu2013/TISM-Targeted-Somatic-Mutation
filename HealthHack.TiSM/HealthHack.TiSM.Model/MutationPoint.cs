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

        public string WT
        {
            get
            {
                return Identifier.Substring(Identifier.Length - 3, 1);
            }
        }
        public string Mut
        {
            get
            {
                return Identifier.Substring(Identifier.Length - 1, 1);
            }
        }
        public string WA_ { get; set; }
        public string _CG { get; set; }
        public string CG_ { get; set; }
        public string WRC_ { get; set; }
        public string _GYW { get; set; }
    }
}
