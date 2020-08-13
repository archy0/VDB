using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.DTOs
{
    public class Art_DokumentsDTO
    {
        public Decimal ID { get; set; }
        public Decimal? DOKTIPS_CD { get; set; }
        public DateTime? DATUMS { get; set; }
        public String NOSAUKUMS { get; set; }

        public String NUMURS { get; set; }
        public String STATUSS { get; set; }
        public Decimal? ORGANIZ_ID { get; set; }
        public String LIETA_NUM { get; set; }
        public String IENAK_NUM { get; set; }
        public String PIEZIMES { get; set; }
        public DateTime? DAT_MOD { get; set; }

        public Art_OrganizDTO Art_Organiz { get; set; }// reference ORGANIZ_ID

        public Art_KonstDTO Art_KonstStatuss { get; set; }//reference STATUSS

        public Art_KonstDTO Art_KonstKods { get; set; }//savieno ar Art_Konst.KODS (lai iegūtu dok. nosaukumu)

        //public List<Art_Dok_Saite> Art_Dok_Saite { get; set; }
    }
}
