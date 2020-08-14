using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.DTOs
{
    public class FilterArg_AdreseDTO
    {

        public decimal ADR_CD { get; set; }
        public decimal TIPS_CD { get; set; }
        public string APSTIPR { get; set; }
        public string STATUSS { get; set; }
        public decimal? APST_PAK { get; set; }
        public string STD { get; set; }
        public decimal VKUR_CD { get; set; } //pagasta ID
        public decimal VKUR_CD_NOV { get; set; } //novada ID, šis nebūs vajadzīgs

        public decimal PagastsID { get; set; } //Pagasta ID
        public decimal NovadsID { get; set; } //novada ID
        public DateTime DAT_SAK { get; set; }
        public DateTime DAT_MOD { get; set; }
        public DateTime DAT_BEIG { get; set; }// Kam šis domāts, nezinu. Gandrīz visi lauki ir null tips.



    }
}
