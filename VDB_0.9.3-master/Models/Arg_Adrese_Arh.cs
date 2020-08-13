using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models
{
    [Table("ARG_ADRESE_ARH", Schema = "TEST_AR")]
    public class Arg_Adrese_Arh
    {
        [Key]
        public Decimal ID { get; set; }
        public Decimal? ADR_CD { get; set; }
        public Decimal? TIPS_CD { get; set; }
        public String? APSTIPR { get; set; }
        public String? STATUSS { get; set; }
        public Decimal? APST_PAK { get; set; }
        public String? STD { get; set; }
        public Decimal? VKUR_CD { get; set; }
        public String? T1 { get; set; }
        public String? T2 { get; set; }
        public String? T3 { get; set; }
        public String? T4 { get; set; }
        public String? T5 { get; set; }
        public String? T6 { get; set; }
        public DateTime? DAT_SAK { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public DateTime? DAT_BEIG { get; set; }

        public Arg_Adrese Arg_adreseAdr { get; set; }//reference ID
    }
}
