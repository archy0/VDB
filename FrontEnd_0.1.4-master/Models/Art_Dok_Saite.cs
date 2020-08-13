using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models {
    public class Art_Dok_Saite {
        public decimal ID { get; set; }
        public decimal DOK_ID { get; set; }
        public decimal VIETA_CD { get; set; }
        public DateTime? DAT_MOD { get; set; }
        //public Arg_Adrese Arg_Adrese { get; set; }
        //public Art_Dokuments Art_Dokuments { get; set; }
    }
}
