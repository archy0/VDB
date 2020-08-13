using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using System.Web.Http.ApiController;//ApiController
using VDB.Data;
using VDB.Models;
using VDB.DTOs;
using VDB.Helpers;

namespace VDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Art_OrganizController : ControllerBase
    // ControllerBase Kontrolieris domātsd priekš API, bez View
    //Controller atbalsta View
    {
        private readonly ILogger<Art_OrganizController> _logger;
        private readonly DataContextAR _context;
        private readonly IMapper _mapper;

        public Art_OrganizController(
          ILogger<Art_OrganizController> logger,
         DataContextAR context1,
         IMapper mapper)
        {
            _logger = logger;
            _context = context1;
            _mapper = mapper;
        }
        // mēģinu izveidot kaut kādu kļūdas paziņojuma klasi
        class ErrorID
        {

            public string error, code;

            // Parameterized Constructor 
            // User defined 
            public ErrorID(string l, string b)
            {
                error = l;
                code = b;
            }

            public string ErrorText()
            {
                return error + ". Kļūda ar kodu " + code; ;
            }
        }


        [HttpGet]// eksperiments - https://localhost:44302/api/art_organiz/get
        [Route("Get2")]
        public string Get2()
        {
            return "Atbilde no WEB API";
        }

        [Route("Get3/{id}")]
        [HttpGet]
        public string Get3(int id)
        {
            return "vērtība = " + id;
        }



        // GET: api/Art_Organiz
        [HttpGet]
        public async Task<ActionResult<List<Art_OrganizDTO>>> GetArt_Organiz_()
        {
            /*return await _context.Art_Organiz_
                //.AsNoTracking()//ar šo metodi strādā ātrāk, jo neveic entītiju ceļa sekošanu
                .ToListAsync();*///asinhroni izveido listi uzskaitot to asinhroni

            var organizacijas = await _context.Art_Organiz_.AsNoTracking().ToListAsync();
            var organizacijasDTOs =
                _mapper.Map
                <List<Art_OrganizDTO>>
                (organizacijas);

            return organizacijasDTOs;


        }

        // filtrēšanas metode
        [HttpGet("filter")]
        public async Task<ActionResult<List<Art_Organiz>>> Filter([FromQuery] Art_Organiz art_Organiz)
        {
            var organizQueryable = _context.Art_Organiz_.AsQueryable();

            if (!string.IsNullOrWhiteSpace(art_Organiz.ABREV))
            {
                organizQueryable = organizQueryable.Where(x => x.ABREV.Contains(art_Organiz.ABREV));
            }

            if (!string.IsNullOrWhiteSpace(art_Organiz.NOSAUKUMS))
            {
                organizQueryable = organizQueryable.Where(x => x.NOSAUKUMS.Contains(art_Organiz.NOSAUKUMS));
            }



            var organiz = await organizQueryable
                .AsNoTracking()//ar šo metodi strādā ātrāk, jo neveic entītiju ceļa sekošanu
                .ToListAsync();

            return organiz;

        }



        [HttpGet("{id}", Name = "GetArt_Organiz")] // api/genres/example
        public async Task<ActionResult<Art_OrganizDTO>> Get(Decimal Id)
        {
            var art_organiz = await _context.Art_Organiz_.FirstOrDefaultAsync(x => x.ID == Id);

            if (art_organiz == null)
            {
                return NotFound();
            }

            var art_OrganizDTO = _mapper.Map<Art_OrganizDTO>(art_organiz);

            return art_OrganizDTO;
        }


        // PUT: api/Art_Organiz/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutArt_Organiz(decimal id, Art_Organiz art_Organiz)
        {
            // atkal mēģinu izveidot kaut kādu kļūdas paziņojuma klasi
            ProblemDetails problemDetails = new ProblemDetails();
            problemDetails.Title = "jop, jop! problēma!";
            problemDetails.Detail = "Labojamais objekts neeksitē!";

            if (id != art_Organiz.ID)
            {
                return BadRequest(problemDetails);
            }

            _context.Entry(art_Organiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Art_OrganizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        [HttpPut("{id}")]
        public async Task<ActionResult> PutArt_Organiz(decimal id, [FromBody] Art_OrganizEditingDTO art_OrganizEditing)
        {
            var organizacija = _mapper.Map<Art_Organiz>(art_OrganizEditing);

            organizacija.ID = id;
            organizacija.DAT_MOD = DateTime.Now;

            _context.Entry(organizacija).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Art_Organiz
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Art_Organiz>> PostArt_Organiz(Art_Organiz art_Organiz)
        //{
        //    Art_Organiz id = _context.Art_Organiz_.Find(art_Organiz.ID);

        //    if (id != null)
        //    {
        //        Console.WriteLine("id aizņemts: " + id.ID);
        //        // Statusa kodi ASP.NET.Core - https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.statuscodes?view=aspnetcore-3.1
        //        // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.conflict?view=aspnetcore-3.1


        //        ErrorID error = new ErrorID("Šāds ID jau eksistē", "409");


        //        return Conflict(error.ErrorText()); ;
        //    }

        //    _context.Art_Organiz_.Add(art_Organiz);

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (Art_OrganizExists(art_Organiz.ID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetArt_Organiz", new { id = art_Organiz.ID }, art_Organiz);
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Art_OrganizCreationDTO art_OrganizCreation)
        {

            var organizacijas = _mapper.Map<Art_Organiz>(art_OrganizCreation);

            Art_Organiz id = _context.Art_Organiz_.Find(art_OrganizCreation.ID);// iegūstu, vai eksistē ID

            if (id != null)// ja tāds ID eksistē, tad Error/Conflict
            {
                Console.WriteLine("id aizņemts: " + id.ID);
                // Statusa kodi ASP.NET.Core - https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.statuscodes?view=aspnetcore-3.1
                // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.conflict?view=aspnetcore-3.1

                ErrorID error = new ErrorID("Šāds ID jau eksistē", "409");

                return Conflict(error.ErrorText()); ;
            }
            else
            {

                _context.Add(organizacijas);

                await _context.SaveChangesAsync();

                var art_OrganizDTO = _mapper.Map<Art_OrganizDTO>(organizacijas);

                art_OrganizDTO.DAT_MOD = DateTime.Now;

                return new CreatedAtRouteResult("getArt_Organiz", new { art_OrganizDTO.ID }, art_OrganizDTO);
                // šeit vajag, lai ņem vērā to, ka ID ģenerējas DB.
                //https://docs.microsoft.com/en-us/ef/core/saving/explicit-values-generated-properties
            }


        }

        [HttpPatch("{id}")]

        /*//POSTMAN PATCH aizpildīšanas sintakses piemērs: 
              [{
		"op": "replace",
		"path" : "/ABREV",
		"value": "AB 9"
    }]
         */
        public async Task<ActionResult> Patch(Decimal id, [FromBody] JsonPatchDocument<Art_OrganizPatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entityFromDB = await _context.Art_Organiz_.FirstOrDefaultAsync(x => x.ID == id);

            if (entityFromDB == null)
            {
                return NotFound();
            }

            var entityDTO = _mapper.Map<Art_OrganizPatchDTO>(entityFromDB);

            patchDocument.ApplyTo(entityDTO, ModelState);

            var isValid = TryValidateModel(entityDTO);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }



            _mapper.Map(entityDTO, entityFromDB);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Art_Organiz>> DeleteArt_Organiz(decimal id)
        {
            var exists = await _context.Art_Organiz_.AnyAsync(x => x.ID == id);

            if (!exists)//ja neeksistē...
            {
                //ProblemDetails problemDetails = new ProblemDetails();
                //problemDetails.Title = "Not Found";
                //problemDetails.Detail = "Dzēšamais objekts neeksitē!";

                //return NotFound(problemDetails);

                return NotFound();
            }

            _context.Remove(new Art_Organiz() { ID = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool Art_OrganizExists(decimal id)
        {
            return _context.Art_Organiz_.Any(e => e.ID == id);
        }
    }
}
