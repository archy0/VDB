using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using VDB.Models;
using VDB.DTOs;
using VDB.Helpers;

namespace VDB.Data
{
    public class DataContextAR : DbContext
    {

        public DataContextAR()
        { }

        public DataContextAR(DbContextOptions<DataContextAR> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // ar šīm metodēm pārraksta dataannotations. Šīs metodes ir spēcīgākas.

            //modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.GenreId, x.MovieId });
            //modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.PersonId, x.MovieId });

            //        modelbuilder.Entity<Art_Konst>()
            //.HasMany(e => e.Art_Dokuments)
            //.WithOne(e => e.Art_Konst)
            //.HasForeignKey(e => e.STATUSS)
            //.HasPrincipalKey(e => e.CHAR3);

            //modelbuilder.Entity<Arg_Adrese>()
            //    .Property(b => b.DAT_BEIG)
            //    .HasDefaultValue(new DateTime());

            modelbuilder.Entity<Art_Konst>()
                .HasMany(q => q.Arg_AdreseKods)
                .WithOne(q => q.Art_KonstTips)
                .HasForeignKey(q => q.TIPS_CD)
                .HasPrincipalKey(q => q.KODS);

            modelbuilder.Entity<Art_Konst>()
                .HasMany(q => q.Arg_AdreseChar3)
                .WithOne(q => q.Art_KonstStatuss)
                .HasForeignKey(q => q.STATUSS)
                .HasPrincipalKey(q => q.CHAR3);

            modelbuilder.Entity<Art_Konst>()
                .HasMany(q => q.Arg_AdreseApstPak)//Apstiprinājuma pakāpe
                .WithOne(q => q.Art_KonstApst_Pak)
                .HasForeignKey(q => q.APST_PAK)
                .HasPrincipalKey(q => q.KODS);


            modelbuilder.Entity<Art_Konst>()
                .HasMany(q => q.Art_DokumentsDokTips)
                .WithOne(q => q.Art_KonstKods)
                .HasForeignKey(q => q.DOKTIPS_CD)
                .HasPrincipalKey(q => q.KODS);

            modelbuilder.Entity<Art_Dokuments>()
                .HasOne<Art_Konst>(s => s.Art_KonstStatuss)
                .WithMany(g => g.Art_Dokuments)
                .HasForeignKey(s => s.STATUSS)
                .HasPrincipalKey(e => e.CHAR3);

            //modelbuilder.Entity<Art_Vieta>()
            //    .HasMany(q => q.Arg_adreseAdr)//Apstiprinājuma pakāpe
            //    .WithOne(q => q.ArtVietaKods)
            //    .HasForeignKey(q => q.ADR_CD)
            //    .HasPrincipalKey(q => q.KODS);

            modelbuilder.Entity<Arg_Adrese>()
                .HasOne(q => q.ArtVietaKods)
                .WithMany(q => q.Arg_adreseAdr)
                .IsRequired(false)
                /* False nozīmē - opcionāla attiecību izvēle. 
                 Šajā gadījumā ne visiem ARG_ADR.ADR_CD ierakstiem ir atbilstoši tāds pats ART_VIETA.KODS ieraksts.*/
                .HasForeignKey(q => q.ADR_CD)
                .HasPrincipalKey(q => q.KODS);

            modelbuilder.Entity<Arg_Adrese_Arh>()
                .HasOne(q => q.Arg_adreseAdr)
                .WithMany(q => q.AdrArhKods)
                .IsRequired(false)
                /* False nozīmē - opcionāla attiecību izvēle. 
                 Šajā gadījumā ne visiem ARG_ADR.ADR_CD ierakstiem ir atbilstoši tāds pats ART_VIETA.KODS ieraksts.*/
                .HasForeignKey(q => q.ADR_CD)
                .HasPrincipalKey(q => q.ADR_CD);

            modelbuilder.Entity<Ciemi>()
                //.HasNoKey()
                .HasOne(c => c.Arg_AdreseKods)
                .WithOne(a => a.CiemiKods)
                .IsRequired(false)
                /* False nozīmē - opcionāla attiecību izvēle. 
                 Šajā gadījumā ne visiem ARG_ADR.ADR_CD ierakstiem ir atbilstoši tāds pats ART_VIETA.KODS ieraksts.*/
                .HasForeignKey<Arg_Adrese>(a => a.ADR_CD)
                .HasPrincipalKey<Ciemi>(c => c.KODS);

            //iekšējā relācija Novads[Pagasti] vajadzībām
            //modelbuilder.Entity<Arg_Adrese>()
            //    .HasOne(a => a.Arg_AdreseCiemi)
            //    .WithMany(c => c.Arg_AdreseCiemi)
            //    .IsRequired(false)
            //    .HasForeignKey(q => q.ADR_CD)
            //    .HasPrincipalKey(q => q.VKUR_CD);





            //modelbuilder.Entity<Arg_AdreseCiemi>()
            //    .HasOne(q => q.Arg_AdreseADR_CD)
            //    .WithMany(q => q.Arg_AdreseCiemi)
            //    .IsRequired(false)
            //    .HasForeignKey(q => q.VKUR_CD)
            //    .HasPrincipalKey(q => q.ADR_CD);

            //modelbuilder.Entity<Arg_Adrese>()
            //    .HasMany(a => a.Arg_AdreseCiemi)
            //    .WithOne(b => b.Arg_AdreseADR_CD)
            //    .IsRequired(false)
            //    .HasForeignKey(a => a.VKUR_CD)
            //    .HasPrincipalKey(b => b.ADR_CD);




            modelbuilder.Entity<Arg_AdreseCiemi>().ToTable("Arg_Adrese");
            modelbuilder.Entity<Arg_AdreseCiemi>().HasKey(x => x.ADR_CD);
            modelbuilder.Entity<Arg_AdreseCiemi>().HasOne(x => x.Arg_AdreseADR_CD)
                .WithMany(x => x.Arg_AdreseCiemi)
                .HasForeignKey(x => x.VKUR_CD)
                .HasPrincipalKey(n => n.ADR_CD);


            //modelbuilder.Entity<Arg_Adrese>().ToTable("Arg_Adrese");
            //modelbuilder.Entity<Arg_Adrese>().HasKey(x => x.ADR_CD);
            //modelbuilder.Entity<Arg_Adrese>().HasMany(x => x.Arg_AdreseCiemi)
            //                                 .WithOne(x => x.Arg_AdreseADR_CD)
            //                                 .HasForeignKey(x => x.ADR_CD)
            //                                 .HasPrincipalKey(n => n.VKUR_CD);




            //modelbuilder.Entity<Arg_AdreseCiemi>()
            //    .HasDiscriminator<decimal>("ADR_CD");

            // ignore a type that is not mapped to a database table
            // modelbuilder.Ignore<Arg_AdreseCiemi>();

            //// ignore a property that is not mapped to a database column
            //modelbuilder.Entity<Arg_AdreseCiemi>()
            //    .Ignore(p => p.Arg_AdreseAdr);



            modelbuilder.Entity<Art_Konst>().ToTable("Art_Konst");
            //modelbuilder.Entity<Art_Konst>().HasKey(x => x.KODS);
            modelbuilder.Entity<Art_Konst>().HasKey(x => new { x.KODS, x.CHAR3 });//defināju, ka ir vairākas key vienā entītijā (klasē)
            modelbuilder.Entity<Art_Konst>().Property(x => x.KODS).IsRequired().ValueGeneratedOnAdd();
            modelbuilder.Entity<Art_Konst>().Property(x => x.NOSAUKUMS).IsRequired().HasMaxLength(30);
            modelbuilder.Entity<Art_Konst>().HasMany(x => x.Arg_AdreseKods).WithOne(x => x.Art_KonstTips).HasForeignKey(x => x.TIPS_CD);// pielieku klāt primary key
            //modelbuilder.Entity<Art_Konst>().HasMany(x => x.Art_Dokuments).WithOne(x => x.Art_KonstStatuss).HasForeignKey(x => x.STATUSS);//pielieku klāt otro key




            modelbuilder.Entity<Art_Dok_NlSaite>().HasKey(x => new { x.DOK_ID, x.NL_CD });

            /* Many-to-many bez otrās entītiju klases reprezentācijas pagaidām netiek atbalstīts.
             Tomēr iespējams many-to-many attiecības uzrakstīt ar diviem atdalītiem mappingiem.*/
            modelbuilder.Entity<Art_Dok_NlSaite>()
                .HasOne<Arg_Adrese>(s => s.Arg_Adrese)
                .WithMany(g => g.Art_Dok_NlSaite)
                .IsRequired(false)
                .HasForeignKey(s => s.NL_CD);

            modelbuilder.Entity<Art_Dok_NlSaite>()
                .HasOne<Art_Dokuments>(a => a.Art_Dokuments)
                .WithMany(g => g.Art_Dok_NlSaite)
                .IsRequired(false)
                .HasForeignKey(a => a.DOK_ID);


            modelbuilder.Entity<Art_Dok_Saite>().HasKey(x => new { x.DOK_ID, x.VIETA_CD });

            modelbuilder.Entity<Art_Dok_Saite>()
                .HasOne<Art_Dokuments>(a => a.Art_Dokuments)
                .WithMany(g => g.Art_Dok_Saite)
                .IsRequired(false)
                .HasForeignKey(a => a.DOK_ID);

            modelbuilder.Entity<Art_Dok_Saite>()
                .HasOne<Arg_Adrese>(s => s.Arg_Adrese)
                .WithMany(g => g.Art_Dok_Saite)
                .IsRequired(false)
                .HasForeignKey(s => s.VIETA_CD);

            modelbuilder.Entity<Art_NLieta>()
                .HasKey(a => a.KODS);

            modelbuilder.Entity<Art_Organiz>().ToTable("Art_Organiz");//Configures the database table that the entity maps to.
            modelbuilder.Entity<Art_Organiz>().HasKey(y => y.ID);//Configures the property or list of properties as Primary Key
            modelbuilder.Entity<Art_Organiz>().Property(y => y.ID).IsRequired().ValueGeneratedOnAdd();
            modelbuilder.Entity<Art_Organiz>().Property(y => y.NOSAUKUMS).IsRequired().HasMaxLength(30);
            modelbuilder.Entity<Art_Organiz>().HasMany(y => y.Art_Dokuments).WithOne(y => y.Art_Organiz).HasForeignKey(y => y.ORGANIZ_ID);

            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Arg_Adrese> Arg_Adrese_ { get; set; }
        public DbSet<Arg_AdreseCiemi> Arg_AdreseCiemi_{ get; set; }
        public DbSet<Arg_Adrese_Arh> Arg_Adrese_Arh_ { get; set; }

        public DbSet<Art_Dok_NlSaite> Art_Dok_NlSaite_ { get; set; }
        public DbSet<Art_Dok_Saite> Art_Dok_Saite_ { get; set; }
        public DbSet<Art_Dokuments> Art_Dokuments_ { get; set; }

        public DbSet<Art_Konst> Art_Konst_ { get; set; }
        public DbSet<Art_Organiz> Art_Organiz_ { get; set; }
        public DbSet<Art_Vieta> Art_Vieta_ { get; set; }

        public DbSet<Ciemi> Ciemi_ { get; set; }
        public DbSet<Art_OrganizDTO> Art_OrganizDTO { get; set; }
        public DbSet<Art_NLieta> Art_NLieta { get; set; }

        //public DbSet<Art_Adm_Ter> Art_Adm_Ter { get; set; }
        //public DbSet<Art_Atrib> Art_Atrib { get; set; }
        //public DbSet<Art_Atrib_Vieta> Art_Atrib_Vieta { get; set; }
        //public DbSet<Art_Dok_DzSaite> Art_Dok_DzSaite { get; set; }

        //public DbSet<Art_Dziv> Art_Dziv { get; set; }
        //public DbSet<Art_Dziv_Num> Art_Dziv_Num { get; set; }
        //public DbSet<Art_Eka_Geo> Art_Eka_Geo { get; set; }
        //public DbSet<Art_Iela_Geo> Art_Iela_Geo { get; set; }
        //public DbSet<Art_Iela_V> Art_Iela_V { get; set; }
        //public DbSet<Art_Iela_V_New> Art_Iela_V_New { get; set; }
        //public DbSet<Art_Kluda> Art_Kluda { get; set; }
        //public DbSet<Art_Kluda_Tips> Art_Kluda_Tips { get; set; }

        //public DbSet<Art_NLieta> Art_NLieta { get; set; }
        //public DbSet<Art_NLNos> Art_NLNos { get; set; }
        //public DbSet<Art_NLSaite> Art_NLSaite_ { get; set; }
        //public DbSet<Art_Nom_Vard> Art_Nom_Vard { get; set; }
        //public DbSet<Art_Nosaukums> Art_Nosaukums { get; set; }
        //public DbSet<Art_Num> Art_Num { get; set; }

        //public DbSet<Art_OrganizDTO> Art_OrganizDTO_ { get; set; }
        //public DbSet<Art_Saite> Art_Saite { get; set; }
        //public DbSet<Art_Tips_Saite> Art_Tips_Saite { get; set; }

        //public DbSet<Art_Vieta_Geo> Art_Vieta_Geo { get; set; }

        //public DbSet<Art_Vieta_Geo> Art_Vieta_Geo { get; set; }
    }

}
