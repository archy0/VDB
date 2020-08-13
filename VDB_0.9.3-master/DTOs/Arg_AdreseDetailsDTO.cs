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
    public class Arg_AdreseDetailsDTO : Arg_AdreseDTO
    {
        public List<Art_DokumentsDTO> Art_Dokuments { get; set; }

        

    }
}
