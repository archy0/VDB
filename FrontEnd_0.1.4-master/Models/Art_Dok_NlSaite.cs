using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models {
    public class Art_Dok_NlSaite {
        public Decimal ID { get; set; }
        public Decimal DOK_ID { get; set; }
        public Decimal NL_CD { get; set; }
        public DateTime? DAT_MOD { get; set; }
        //public Arg_Adrese Arg_Adrese { get; set; }
        //public Art_Dokuments Art_Dokuments { get; set; }
    }
}
