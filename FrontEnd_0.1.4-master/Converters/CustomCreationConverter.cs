using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json; // JSON atribūti, u.c.
using Newtonsoft.Json.Linq;//JObject
using Newtonsoft.Json.Converters;// CustomCreationConverter

// varbūt šis viss ir neizmantojams un jādzēš ārā.
//izveidoju īpašu klasi deserializācijai, lai konvertētu datus citādākā klasē

namespace FrontEnd.Converters
{



    public interface IArg_Adrese
    {
        //string TIPS_CD { get; set; }
        String STATUSS { get; set; }
    }
    //[JsonObject(MemberSerialization.OptIn)]
    public class Details : IArg_Adrese
        {
            public decimal ADR_CD { get; set; }
        //private string tips_cd { get; set; }

            public string TIPS_CD 
            {
                get { return art_KonstTips.NOSAUKUMS; }
            } 
            

            public Art_KonstTips art_KonstTips { get; set; }

            public class Art_KonstTips
            {
                public Decimal KODS { get; set; }
                public Decimal? KODIF { get; set; }
                public String CHAR3 { get; set; }
                public String NOSAUKUMS { get; set; }
                public String ABREV { get; set; }
            }

            //public string art_konsttips
            //{
            //    get { return this.art_konsttips; }
            //    set { this.art_konsttips = Art_KonstTips.NOSAUKUMS; }
            //}



            public String STD { get; set; }

            public String APSTIPR { get; set; }
            public String STATUSS { get; set; }
            public String APST_PAK { get; set; }
            public Decimal VKUR_CD { get; set; }
            public DateTime DAT_SAK { get; set; }
            public DateTime? DAT_MOD { get; set; }
            public DateTime? DAT_BEIG { get; set; }

            public List<Art_Dokuments> art_Dokuments { get; set; }

            public class Art_Dokuments
            {
                public Decimal ID { get; set; }
                public Decimal? DOKTIPS_CD { get; set; }
                public DateTime? DATUMS { get; set; }
                public String NOSAUKUMS { get; set; }

                public String NUMURS { get; set; }
                public String STATUSS { get; set; }
                public Decimal? ORGANIZ_ID { get; set; }
                public String LIETA_NUM { get; set; }
                public String IENAK_NUM { get; set; }
                public String PIEZIMES { get; set; }
                public DateTime? DAT_MOD { get; set; }
            }


        }

        public class Arg_AdreseConverter : CustomCreationConverter<IArg_Adrese>
        {
            public override IArg_Adrese Create(Type objectType)
            {
                return new Details();
            }
        }
    
}
