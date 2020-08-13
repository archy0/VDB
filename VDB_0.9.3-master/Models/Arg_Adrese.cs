using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VDB.Helpers;


//http://www.hackered.co.uk/articles/sorting-c-sharp-nullable-datetime-columns-by-nulls-followed-by-datetime-descending //Sorting C# nullable DateTime columns by nulls followed by DateTime descending
namespace VDB.Models

//https://www.tutorialsteacher.com/csharp/csharp-nullable-types //Characteristics of Nullable Types
//https://www.codeproject.com/Questions/250155/how-to-assign-null-value-to-datetime-in-Csharp-net
//https://stackoverflow.com/questions/2017533/best-way-to-check-if-column-returns-a-null-value-from-database-to-net-applicat
//https://csharp.christiannagel.com/2017/01/25/expressionbodiedmembers/
//https://www.c-sharpcorner.com/article/expression-bodied-members/
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
{



    [Table("ARG_ADRESE", Schema = "TEST_AR")]
    public class Arg_Adrese

    {
        // Iespējams, jālieto Sql tipi no System.Data.SqlTypes Namespace , piem., SqlDecimal (https://docs.microsoft.com/en-us/dotnet/api/system.data.sqltypes?view=netcore-3.1)
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required(ErrorMessage = "Lauks {0} ir obligāti aizpildāms.")]
        //[StringLength(11, MinimumLength = 9)]// nevis StringLength, bet integrālis tur ir

        [Display(Name = "Kods")]
        public decimal ADR_CD { get; set; }

        [Display(Name = "Tips")]
        public Decimal TIPS_CD { get; set; }

        public string pilnsStatuss// eksperimenta lauciņš
        {
            get { return APSTIPR + STATUSS; }
        }

        
        public String APSTIPR { get; set; }

        [Display(Name = "Statuss")]
        public String STATUSS { get; set; }
        public Decimal? APST_PAK { get; set; }

        [Display(Name = "Adrese")]
        [MaxLength(256)]
        public String STD { get; set; }
        public Decimal VKUR_CD { get; set; }

       
        public String T1 { get; set; }
        public String T2 { get; set; }
        public String T3 { get; set; }

        public String T4 { get; set; }
        public String T5 { get; set; }
        public String T6 { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Sākuma dat.")]
        public DateTime DAT_SAK { get; set; }

        [DataType(DataType.Date)]

        [Display(Name = "Pēd. modif. dat.")]

        //public DateTime? DAT_MOD { get; set; }

        private DateTime? DAT_MOD;// pilna get-set metode
        public DateTime dat_mod
        {
            set => DAT_MOD = value;
            //get => DAT_MOD ?? throw new InvalidOperationException("Uninitialized property: " + nameof(dat_mod));
            get => DAT_MOD ?? new DateTime();

        }

        public DateTime? DAT_BEIG { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<Art_Dok_NlSaite>>))]//vai šo man vajag?
        public List<Art_Dok_NlSaite> Art_Dok_NlSaite { get; set; }

        public List<Art_Dok_Saite> Art_Dok_Saite { get; set; }

        public Art_Konst Art_KonstTips { get; set; }//reference TIPS_CD

        public Art_Konst Art_KonstStatuss { get; set; }// reference STATUSS

        public Art_Konst Art_KonstApst_Pak { get; set; }// reference APST_PAK

        public Art_Vieta ArtVietaKods { get; set; }//reference TIPS_CD

        public Ciemi CiemiKods { get; set; }//reference TIPS_CD

        public List<Arg_Adrese_Arh> AdrArhKods { get; set; }//reference TIPS_CD

        public List<Arg_AdreseCiemi> Arg_AdreseCiemi { get; set; }

       //public List<Art_NLieta> Art_NLieta { get; set; }


    }

}


