#nullable enable //https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models
{
    [Table("ART_ORGANIZ", Schema = "TEST_AR")]
    public class Art_Organiz
    {
        [Key]
        public decimal ID { get; set; }

        [Required]
        public string? NOSAUKUMS { get; set; }

        [Display(Name = "Abrevatūra")]
        public string? ABREV { get; set; }

        //private string? ABREV;
        
        //public string? Abrev
        //{
        //    get
        //    {
        //        return ABREV;
        //    }
        //    set
        //    {
        //        if (value == null) { ABREV = "bez abrevatūras"; }
        //        else { ABREV = value; }
        //    }
        //}

        [Display(Name = "Modificēts")]

        [DataType(DataType.Date)]
        public DateTime? DAT_MOD { get; set; }

        public List<Art_Dokuments> Art_Dokuments { get; set; }

    }
}
