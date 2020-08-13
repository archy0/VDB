using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VDB.Helpers;

namespace VDB.Models
{
    [Table("CIEMI", Schema = "TEST_AR")]
    public class Ciemi
    {
        //bez Primary Key
        [Key]// bez šī Key nav iespējams (nemāku/EF Core neērti risinājumi) veidot klašu attiecības 
        public Decimal? KODS { get; set; }
        public Decimal? TIPS_CD { get; set; }
        public String STATUSS { get; set; }
        public String APSTIPR { get; set; }
        public Decimal? APST_PAK { get; set; }
        public Decimal? VKUR_CD { get; set; }
        public Decimal? VKUR_TIPS { get; set; }
        public String NOSAUKUMS { get; set; }
        public String SORT_NOS { get; set; }
        public String ATRIB { get; set; }
        public DateTime? DAT_SAK { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public DateTime? DAT_BEIG { get; set; }
        public Decimal? MSLINK { get; set; }

        public Arg_Adrese Arg_AdreseKods { get; set; } //lai piliktu pie ARG_ADR klāt ATRIB (6 cip. kodu)
    }
}
