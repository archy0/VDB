using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models {

    [Table("ART_NLIETA", Schema = "TEST_AR")]
    public class Art_NLieta {
        [Key]
        public decimal KODS { get; set; }
        public decimal? TIPS_CD { get; set; }
        public string STATUSS { get; set; }
        public string APSTIPR { get; set; }
        public decimal? APST_PAK { get; set; }
        public decimal? VKUR_CD { get; set; }
        public decimal? VKUR_TIPS { get; set; }
        public string NOSAUKUMS { get; set; }
        public string SORT_NOS { get; set; }
        public string ATRIB { get; set; }
        public decimal? PNOD_CD { get; set; }
        public DateTime? DAT_SAK { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public DateTime? DAT_BEIG { get; set; }
        public string FOR_BUILD { get; set; }
    }
}
