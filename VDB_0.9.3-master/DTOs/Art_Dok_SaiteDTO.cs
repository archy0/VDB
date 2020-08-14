using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.DTOs {
    public class Art_Dok_SaiteDTO {
        public decimal ID { get; set; }
        public decimal DOK_ID { get; set; }
        public decimal VIETA_CD { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public Arg_AdreseDTO Arg_Adrese { get; set; }
        public Art_DokumentsDTO Art_Dokuments { get; set; }
    }
}
