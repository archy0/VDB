#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.DTOs
{
     public class Art_OrganizDTO// DTO - data trabsfer object
    /*
    Data transfēra objekts tiek pasniegts bez datu anotācijām, lai nerastos problēmas.
     */
    {
        //ja atstāj šo Required, tad meklēšanas laukā obligāti(!) šis lauks ir aizpildāms, kas ne vienmēr ir vajadzīgs
        public decimal ID { get; set; }
        public String? NOSAUKUMS { get; set; }
        public String? ABREV { get; set; }
        public DateTime? DAT_MOD { get; set; }
    }
}
