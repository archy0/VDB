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
    public class Art_OrganizEditingDTO
    {
        public decimal ID { get; set; }//Pagaidām datubāzē ID nav autoincrement. Tāpēc tas jādefinē servera pusē.
        public String? NOSAUKUMS { get; set; }
        public String? ABREV { get; set; }
        public DateTime? DAT_MOD { get; set; }
    }
}
