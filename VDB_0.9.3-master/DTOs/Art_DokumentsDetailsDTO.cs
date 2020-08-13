using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.DTOs
{
    public class Art_DokumentsDetailsDTO : Art_DokumentsDTO
    {
        public List<Arg_AdreseDTO> Arg_Adrese { get; set; }
    }
}
