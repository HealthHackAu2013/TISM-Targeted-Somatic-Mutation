using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthHack.TiSM.Model
{
    public class Mutation
    {
        public string Gene { get; set; } 
        public string Transscript { get; set; }
        public string AAMutation { get; set; }
        public MutationPoint CDSMutation { get; set; }
        public string Somaticstatus { get; set; }
        public string Zygosity { get; set; }
        public string Validated { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public string MutatedCodon { get; set; }
        public string PreviousCodon { get; set; }
        public string NextCodon { get; set; }
        public string ProcessOutput { get; set; }

        public string getCDNAFileName(string dataDirectory) {
            string specificTranscriptFile = dataDirectory + Gene + @"_" + Transscript + @".txt";
            string geneFile =  dataDirectory + Gene + @".txt"
            if (File.Exists(specificTranscriptFile)) {
                return specificTranscriptFile;
            } else {
                return geneFile;
            }


        }
    }
}
