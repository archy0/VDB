using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Art_Konst
    {
        public Decimal KODS { get; set; }
        public Decimal? KODIF { get; set; }
        public String CHAR3 { get; set; }
        public String NOSAUKUMS { get; set; }
        public String ABREV { get; set; }
        public String BOOL { get; set; }
        public Decimal? NUM { get; set; }
        public String STR { get; set; }
        public Decimal? NUM2 { get; set; }
        public String FMT { get; set; }
        public String PIEZ { get; set; }
        public DateTime? DAT_MOD { get; set; }

        //public List<Arg_Adrese> Arg_AdreseChar3 { get; set; }//reference CHAR3 (varbūt nosaukt Arg_AdreseStatuss ?)

        //public List<Arg_Adrese> Arg_AdreseKods { get; set; }//reference KODS (varbūt nosaukt Arg_AdreseTips ?)

        //public List<Arg_Adrese> Arg_AdreseApstPak { get; set; }//reference KODS (ARG_ADRESE.APST_PAK vajadzībām)

        //public List<Art_Dokuments> Art_Dokuments { get; set; }

        //public List<Art_Dokuments> Art_DokumentsDokTips { get; set; }//reference KODS. Šis attiecas uz ArtDokumentsDokTips

    }
}
