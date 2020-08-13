using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VDB.Helpers;

namespace VDB.DTOs
{
    public class Art_KonstDTO
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

    }
}
