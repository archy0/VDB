using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models {
    public class Arg_AdreseCiemi {
        public decimal ADR_CD { get; set; }

        public Decimal TIPS_CD { get; set; }

        public String APSTIPR { get; set; }

        public String STATUSS { get; set; }
        public Decimal? APST_PAK { get; set; }

        public String STD { get; set; }
        public Decimal VKUR_CD { get; set; }

        public DateTime DAT_SAK { get; set; }

        public DateTime? DAT_MOD;// pilna get-set metode
        public DateTime? DAT_BEIG { get; set; }
        //public Art_Konst Art_KonstStatuss { get; set; }// reference STATUSS        

        //public Arg_Adrese Arg_AdreseADR_CD { get; set; }
    }
}
