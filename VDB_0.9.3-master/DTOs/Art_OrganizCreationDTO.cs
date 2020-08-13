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
    public class Art_OrganizCreationDTO : Art_OrganizPatchDTO//šī klase tiek ņemta no citurienes. Var arī tā nedarīt, protams.
    {
        public decimal ID { get; set; }//Pagaidām datubāzē ID nav autoincrement. Tāpēc tas jādefinē servera pusē.

    }
}
