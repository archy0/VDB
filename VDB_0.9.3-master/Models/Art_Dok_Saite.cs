using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models
{
    [Table("ART_DOK_SAITE", Schema = "TEST_AR")]
    public class Art_Dok_Saite
    {

        [Key]
        public Decimal ID { get; set; }
        public Decimal DOK_ID { get; set; }
        public Decimal VIETA_CD { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public Arg_Adrese Arg_Adrese { get; set; }
        public Art_Dokuments Art_Dokuments { get; set; }
    }
}
