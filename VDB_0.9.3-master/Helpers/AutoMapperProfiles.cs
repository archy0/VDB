using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VDB.DTOs;
using VDB.Models;

namespace VDB.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        
        public AutoMapperProfiles() 
        {

            CreateMap<Art_Dokuments, Art_DokumentsDTO>()/*.ReverseMap()*/;


            CreateMap<Art_Dokuments, Art_DokumentsDetailsDTO>()
            .ForMember(x => x.Arg_Adrese, options => options.MapFrom(MapArt_Dok_Saite));

            CreateMap<Art_OrganizCreationDTO, Art_Organiz>();

            CreateMap<Art_OrganizEditingDTO, Art_Organiz>();

            CreateMap<Art_Organiz, Art_OrganizPatchDTO>().ReverseMap();


            CreateMap<Arg_Adrese, Arg_AdreseDTO>().ReverseMap();

            CreateMap<Arg_AdreseCiemi, Arg_AdreseCiemiDTO>().ReverseMap();

            CreateMap<Art_Konst, Art_KonstDTO>().ReverseMap();


            CreateMap<Art_Organiz, Art_OrganizDTO>().ReverseMap();

            CreateMap<Art_Vieta, Art_VietaDTO>().ReverseMap();


            CreateMap<Ciemi, CiemiDTO>().ReverseMap();

            CreateMap<Arg_Adrese_Arh, Arg_Adrese_ArhDTO>().ReverseMap();

            CreateMap<Arg_Adrese, Arg_AdreseDetailsDTO>().ForMember(x => x.Art_Dokuments, options => options.MapFrom(MapArt_Dok_NlSaite));

            CreateMap<Art_NLieta, Art_NLietaDTO>().ReverseMap();
        }

        private List<Art_DokumentsDTO> MapArt_Dok_NlSaite(Arg_Adrese arg_Adrese, Arg_AdreseDetailsDTO arg_AdreseDetailsDTO)
        {
            var result = new List<Art_DokumentsDTO>();
            foreach (var art_Dok_NlSaite in arg_Adrese.Art_Dok_NlSaite)
            {
                result.Add(new Art_DokumentsDTO() {
                    Art_Organiz = new Art_OrganizDTO()
                    {
                        ID = art_Dok_NlSaite.Art_Dokuments.Art_Organiz.ID,
                        NOSAUKUMS = art_Dok_NlSaite.Art_Dokuments.Art_Organiz.NOSAUKUMS,
                        ABREV = art_Dok_NlSaite.Art_Dokuments.Art_Organiz.ABREV,
                        DAT_MOD = art_Dok_NlSaite.Art_Dokuments.Art_Organiz.DAT_MOD
                    },

                    ID = art_Dok_NlSaite.DOK_ID,
                    DOKTIPS_CD = art_Dok_NlSaite.Art_Dokuments.DOKTIPS_CD,

                    Art_KonstKods = new Art_KonstDTO()
                    {
                        KODS = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.KODS,
                        KODIF = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.KODIF,
                        CHAR3 = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.CHAR3,
                        NOSAUKUMS = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.NOSAUKUMS,
                        ABREV = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.ABREV,
                        BOOL = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.BOOL,
                        NUM = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.NUM,
                        STR = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.STR,
                        NUM2 = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.NUM2,
                        FMT = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.FMT,
                        PIEZ = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.PIEZ,
                        DAT_MOD = art_Dok_NlSaite.Art_Dokuments.Art_KonstKods.DAT_MOD
                    },
                    DATUMS = art_Dok_NlSaite.Art_Dokuments.DATUMS,
                    NOSAUKUMS = art_Dok_NlSaite.Art_Dokuments.NOSAUKUMS,
                    NUMURS = art_Dok_NlSaite.Art_Dokuments.NUMURS,
                    STATUSS = art_Dok_NlSaite.Art_Dokuments.STATUSS,

                    Art_KonstStatuss = new Art_KonstDTO()
                    {
                        KODS = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.KODS,
                        KODIF = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.KODIF,
                        CHAR3 = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.CHAR3,
                        NOSAUKUMS = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.NOSAUKUMS,
                        ABREV = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.ABREV,
                        BOOL = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.BOOL,
                        NUM = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.NUM,
                        STR = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.STR,
                        NUM2 = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.NUM2,
                        FMT = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.FMT,
                        PIEZ = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.PIEZ,
                        DAT_MOD = art_Dok_NlSaite.Art_Dokuments.Art_KonstStatuss.DAT_MOD
                    },

                    ORGANIZ_ID = art_Dok_NlSaite.Art_Dokuments.ORGANIZ_ID,
                    LIETA_NUM = art_Dok_NlSaite.Art_Dokuments.LIETA_NUM,
                    IENAK_NUM = art_Dok_NlSaite.Art_Dokuments.IENAK_NUM,
                    PIEZIMES = art_Dok_NlSaite.Art_Dokuments.PIEZIMES,
                    DAT_MOD = art_Dok_NlSaite.DAT_MOD

                });;
            }
            return result;
        }

        private List<Arg_AdreseDTO> MapArt_Dok_Saite(Art_Dokuments art_Dokuments, Art_DokumentsDetailsDTO art_DokumentsDetailsDTO)
        {
            var result = new List<Arg_AdreseDTO>();

            foreach (var art_Dok_Saite in art_Dokuments.Art_Dok_Saite)
            {
                result.Add(new Arg_AdreseDTO()
                {

                    ADR_CD = art_Dok_Saite.VIETA_CD,
                    TIPS_CD = art_Dok_Saite.Arg_Adrese.TIPS_CD,
                    APSTIPR = art_Dok_Saite.Arg_Adrese.APSTIPR,
                    STATUSS = art_Dok_Saite.Arg_Adrese.STATUSS,
                    APST_PAK = art_Dok_Saite.Arg_Adrese.APST_PAK,
                    STD = art_Dok_Saite.Arg_Adrese.STD,
                    VKUR_CD = art_Dok_Saite.Arg_Adrese.VKUR_CD,
                    DAT_SAK = art_Dok_Saite.Arg_Adrese.DAT_SAK,
                    DAT_MOD = art_Dok_Saite.Arg_Adrese.dat_mod,
                    DAT_BEIG = art_Dok_Saite.Arg_Adrese.DAT_BEIG,
                    Art_KonstStatuss = new Art_KonstDTO()
                    {
                        KODS = art_Dok_Saite.Arg_Adrese.Art_KonstStatuss.KODS,
                        KODIF = art_Dok_Saite.Arg_Adrese.Art_KonstStatuss.KODIF,
                        CHAR3 = art_Dok_Saite.Arg_Adrese.Art_KonstStatuss.CHAR3,
                        NOSAUKUMS = art_Dok_Saite.Arg_Adrese.Art_KonstStatuss.NOSAUKUMS,
                        ABREV = art_Dok_Saite.Arg_Adrese.Art_KonstStatuss.ABREV,
                        BOOL = art_Dok_Saite.Arg_Adrese.Art_KonstStatuss.BOOL
                    },

                    Art_KonstTips = new Art_KonstDTO()
                    {
                        KODS = art_Dok_Saite.Arg_Adrese.Art_KonstTips.KODS,
                        KODIF = art_Dok_Saite.Arg_Adrese.Art_KonstTips.KODIF,
                        CHAR3 = art_Dok_Saite.Arg_Adrese.Art_KonstTips.CHAR3,
                        NOSAUKUMS = art_Dok_Saite.Arg_Adrese.Art_KonstTips.NOSAUKUMS,
                        ABREV = art_Dok_Saite.Arg_Adrese.Art_KonstTips.ABREV,
                        BOOL = art_Dok_Saite.Arg_Adrese.Art_KonstTips.BOOL
                    }

                });
            }

            return result;

        }

    }
}
