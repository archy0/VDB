using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models
{
    [Table("ART_DOKUMENTS", Schema = "TEST_AR")]
    public class Art_Dokuments
    {
        [Key]
        public Decimal ID { get; set; }
        public Decimal? DOKTIPS_CD { get; set; }
        public DateTime? DATUMS { get; set; }
        public String NOSAUKUMS { get; set; }

        //[StringLength(64)]//eksperiments
        //public string? NUMURS { get; set; }
        public String NUMURS { get; set; }
        public String STATUSS { get; set; }
        public Decimal? ORGANIZ_ID { get; set; }
        public String LIETA_NUM { get; set; }
        public String IENAK_NUM { get; set; }
        public String PIEZIMES { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public List<Art_Dok_NlSaite> Art_Dok_NlSaite { get; set; }

        public List<Art_Dok_Saite> Art_Dok_Saite { get; set; }

        public Art_Organiz Art_Organiz { get; set; }

        [ForeignKey("STATUSS")]
        public Art_Konst Art_KonstStatuss { get; set; }

        [ForeignKey("DOKTIPS_CD")]
        public Art_Konst Art_KonstKods { get; set; }//savieno ar Art_Konst.KODS (lai iegūtu dok. nosaukumu)
    }
}
