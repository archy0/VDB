using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.DTOs
{
    public class Arg_AdreseDTO

    {
        public decimal ADR_CD { get; set; }
        public Decimal TIPS_CD { get; set; }
        public String APSTIPR { get; set; }
        public String STATUSS { get; set; }
        public Decimal? APST_PAK { get; set; }
        public String STD { get; set; }
        public Decimal VKUR_CD { get; set; }
        public DateTime DAT_SAK { get; set; }
        public DateTime? DAT_MOD { get; set; }

        public DateTime? DAT_BEIG { get; set; }

        public Art_KonstDTO Art_KonstTips { get; set; }// reference TIPS_CD

        public Art_KonstDTO Art_KonstStatuss { get; set; }// reference STATUSS

        public Art_KonstDTO Art_KonstApst_Pak { get; set; }// reference APST_PAK

        public Art_VietaDTO ArtVietaKods { get; set; }//reference TIPS_CD

        public CiemiDTO CiemiKods { get; set; }//pielieku klāt IR 6 ciparu kodu

        public List<Arg_Adrese_ArhDTO> AdrArhKods { get; set; }//reference TIPS_CD

        public List<Arg_AdreseCiemiDTO> Arg_AdreseCiemi { get; set; }


    }
}
