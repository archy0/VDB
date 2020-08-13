using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models
{
    public class Art_Atrib
    {
        public Decimal ATRTIPS_CD { get; set; }
        public Decimal VIETA_CD { get; set; }
        public String TEKSTS { get; set; }
        public DateTime? DAT_MOD { get; set; }

        [Key]
        public Decimal ID { get; set; }
    }
}
