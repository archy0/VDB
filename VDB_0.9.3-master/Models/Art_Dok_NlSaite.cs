using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDB.Models
{
    [Table("ART_DOK_NLSAITE", Schema = "TEST_AR")]
    public class Art_Dok_NlSaite
    {
        [Key]
        public Decimal ID { get; set; }
        public Decimal DOK_ID { get; set; }
        public Decimal NL_CD { get; set; }
        public DateTime? DAT_MOD { get; set; }
        public Arg_Adrese Arg_Adrese { get; set; }
        public Art_Dokuments Art_Dokuments { get; set; }

    }
}
/*
       SELECT [t].[ADR_CD], [t].[APSTIPR], [t].[APST_PAK], [t].[DAT_SAK], [t].[STATUSS], [t].[STD], 
	  [t].[T1], [t].[T2], [t].[T3], [t].[T4], [t].[T5], [t].[T6], 
	  [t].[TIPS_CD], [t].[VKUR_CD], [t].[dat_beig], [t].[dat_mod], 
	  [t0].[DOK_ID], [t0].[NL_CD], [t0].[Arg_AdreseADR_CD], [t0].[Art_DokumentsID], [t0].[DAT_MOD], [t0].[ID],
	  [t0].[ID0], [t0].[DATUMS], [t0].[DAT_MOD0], [t0].[DOKTIPS_CD], [t0].[IENAK_NUM], 
	  [t0].[LIETA_NUM], [t0].[NOSAUKUMS], [t0].[NUMURS], [t0].[ORGANIZ_ID], [t0].[PIEZIMES], [t0].[STATUSS]
      FROM (
          SELECT TOP(1) [a].[ADR_CD], [a].[APSTIPR], [a].[APST_PAK], [a].[DAT_SAK], [a].[STATUSS], [a].[STD], 
		  [a].[T1], [a].[T2], [a].[T3], [a].[T4], [a].[T5], [a].[T6], 
		  [a].[TIPS_CD], [a].[VKUR_CD], [a].[dat_beig], [a].[dat_mod]
          FROM [TEST_AR].[ARG_ADRESE] AS [a]
          WHERE [a].[ADR_CD] = @__id_0
		  ) AS [t]
		  LEFT JOIN (
			  SELECT [a0].[DOK_ID], [a0].[NL_CD], [a0].[Arg_AdreseADR_CD], [a0].[Art_DokumentsID], [a0].[DAT_MOD], [a0].[ID], 
			  [a1].[ID] AS [ID0], [a1].[DATUMS], [a1].[DAT_MOD] AS [DAT_MOD0], [a1].[DOKTIPS_CD], [a1].[IENAK_NUM], [a1].[LIETA_NUM], 
			  [a1].[NOSAUKUMS], [a1].[NUMURS], [a1].[ORGANIZ_ID], [a1].[PIEZIMES], [a1].[STATUSS]
			  FROM [TEST_AR].[ART_DOK_NLSAITE] AS [a0]
			  LEFT JOIN [TEST_AR].[ART_DOKUMENTS] AS [a1] ON [a0].[Art_DokumentsID] = [a1].[ID]
		  ) AS [t0] ON [t].[ADR_CD] = [t0].[Arg_AdreseADR_CD]

 */
