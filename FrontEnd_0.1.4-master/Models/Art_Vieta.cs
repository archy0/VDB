using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Art_Vieta
    {
        public Decimal KODS { get; set; }
        public Decimal? TIPS_CD { get; set; }
        public String? STATUSS { get; set; }
        public String? APSTIPR { get; set; }
        public Decimal? APST_PAK { get; set; }
        public Decimal? VKUR_CD { get; set; }
        public Decimal? VKUR_TIPS { get; set; }
        public String? NOSAUKUMS { get; set; }
        public String? SORT_NOS { get; set; }
        public String? ATRIB { get; set; }
        public DateTime? DAT_SAK { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public DateTime? DAT_BEIG { get; set; }
    }
}
