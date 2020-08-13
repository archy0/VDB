using System;
using System.Collections.Generic;
using System.ComponentModel;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Arg_Adrese

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

        public Art_Konst Art_KonstTips { get; set; }// reference TIPS_CD

        public Art_Konst Art_KonstStatuss { get; set; }// reference STATUSS

        public Art_Konst Art_KonstApst_Pak { get; set; }// reference APST_PAK

        public Art_Vieta ArtVietaKods { get; set; }//reference TIPS_CD

        public Ciemi CiemiKods { get; set; }//pielieku klāt IR 6 ciparu kodu

        public List<Arg_Adrese_Arh> AdrArhKods { get; set; }//reference TIPS_CD

        public List<Art_Dokuments> Art_Dokuments { get; set; }
    }
    
}
