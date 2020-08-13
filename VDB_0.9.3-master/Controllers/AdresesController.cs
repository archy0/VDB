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
using Newtonsoft.Json;

namespace VDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdresesController : ControllerBase

    //ControllerBase - ar REST API atbalstu, bez View atbalsta
    //Controller  - ar View atbalstu
    {

        private readonly ILogger<AdresesController> _logger;
        private readonly DataContextAR _context;
        private readonly IMapper _mapper;

        public AdresesController(
          ILogger<AdresesController> logger,
         DataContextAR context,
         IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Adreses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arg_Adrese>>> GetArg_Adrese_()
        {
            return await _context.Arg_Adrese_
             .AsNoTracking() //ar šo metodi strādā ātrāk, jo neveic entītiju ceļa sekošanu
             .ToListAsync();
        }

        // GET: api/Adreses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arg_Adrese>> GetArg_Adrese(decimal id)
        {
            var arg_Adrese = await _context.Arg_Adrese_.FindAsync(id);

            if (arg_Adrese == null)
            {
                return NotFound();
            }

            return arg_Adrese;
        }

        [Route("Detalas/{id}")]
        [HttpGet("{id}", Name = "getAdrese")]
        public async Task<ActionResult<Arg_AdreseDetailsDTO>> GetDetails(decimal id)
        {
            var adrese = 
                await _context.Arg_Adrese_
                .Include(z => z.Art_KonstTips)
                .Include(z => z.Art_KonstApst_Pak)
                .Include(z => z.ArtVietaKods)
                .Include(z => z.CiemiKods)
                .Include(z => z.AdrArhKods)
                .Include(z => z.Art_KonstStatuss)
                .Include(z => z.Art_Dok_NlSaite).ThenInclude(z => z.Art_Dokuments).ThenInclude(n => n.Art_Organiz)
                .Include(z => z.Art_Dok_NlSaite).ThenInclude(z => z.Art_Dokuments).ThenInclude(n => n.Art_KonstStatuss)
                .Include(z => z.Art_Dok_NlSaite).ThenInclude(z => z.Art_Dokuments).ThenInclude(n => n.Art_KonstKods)
                              
                .FirstOrDefaultAsync(n => n.ADR_CD == id);

            if (adrese == null)
            {
                return NotFound();
            }

            var arg_AdreseDetailsDTO = 
                _mapper
                .Map
                <Arg_AdreseDetailsDTO>
                (adrese);

            return arg_AdreseDetailsDTO;
            //return _mapper
            //    .Map
            //    <Arg_AdreseDetailsDTO>
            //    (adrese);
            Console.WriteLine("ADR_CD: " + arg_AdreseDetailsDTO.ADR_CD);
        }


        [Route("satur/{id}")]
        [HttpGet("{id}")]
        
        public async Task<ActionResult<List<Arg_AdreseDTO>>> Satur(decimal id)
        {

            var satur_List =
               await _context.Arg_Adrese_
              .Where(n => n.VKUR_CD == id && n.STATUSS == "EKS")
               .Include(q => q.Art_KonstTips)
               .Include(q => q.Art_KonstStatuss)
               .ToListAsync();


            if (satur_List == null)
            {
                return NotFound();
            }

            var arg_AdreseDTO =
                _mapper
                .Map
                <List<Arg_AdreseDTO>>
                (satur_List);

            Console.WriteLine("satur (arg_AdreseDTO) : " + arg_AdreseDTO);

            return arg_AdreseDTO;
        }
               

        [HttpGet]
        [Route("GetNovadi2")]
        public async Task<ActionResult<List<Arg_AdreseDTO>>> GetNovadi2()
        {
            //iegūst novadus + Rep.pilsētas
            var adreses = await _context.Arg_Adrese_
                 .Where(n => n.TIPS_CD == 113 && n.STATUSS == "EKS" || n.TIPS_CD == 104 && n.STATUSS == "EKS" && n.VKUR_CD == 100000000)
                 .OrderBy(n => n.STD)
                .AsNoTracking()//ar šo metodi strādā ātrāk, jo neveic entītiju ceļa sekošanu
                .ToListAsync();//asinhroni izveido listi uzskaitot to asinhroni

            var adresesDTOs =
                _mapper.Map
                <List<Arg_AdreseDTO>>
                (adreses);

            return adresesDTOs;

        }


        [HttpGet]
        [Route("GetNovadi")]
        public async Task<ActionResult<List<Arg_AdreseDTO>>> GetNovadi()
        {
            //iegūst tikai novadus (bez Rep. pilsētām)
            var adreses = await _context.Arg_Adrese_
                .Where(n => n.TIPS_CD == 113 && n.STATUSS == "EKS")
                .OrderBy(n => n.STD)
                .AsNoTracking()//ar šo metodi strādā ātrāk, jo neveic entītiju ceļa sekošanu. Izdevīgs read-only scenārijā.
                .ToListAsync();

            var adresesDTOs =
                _mapper.Map
                <List<Arg_AdreseDTO>>
                (adreses);

            return adresesDTOs;
        }

        [Route("GetPagasti/NovadsID={NovadsID}")]
        [HttpGet("{NovadsID}")]

        //https://localhost:44302/api/adreses/getPagasti/NovadsID=100015307
        public IEnumerable<Arg_Adrese> GetPagasti(decimal NovadsID)
        {

            List<Arg_Adrese> pagasti_List = new List<Arg_Adrese>();

            pagasti_List = (from pagasts in _context.Arg_Adrese_ where pagasts.VKUR_CD == NovadsID && (pagasts.TIPS_CD == 104 || pagasts.TIPS_CD == 105) orderby pagasts.T6 ascending select pagasts).ToList();

            //var novadi = _context.Arg_Adrese_.Where(n => n.tips_cd == 113 && n.STATUSS == "EKS" || n.tips_cd == 104 && n.STATUSS == "EKS").ToList();

            return pagasti_List;

        }

        //[Route("PagastiCiemi/NovadsID={NovadsID}")]
        //[HttpGet("{NovadsID}")]

        ////https://localhost:44302/api/adreses/getPagasti/NovadsID=100015307
        //public IEnumerable<Arg_Adrese> GetPagastiCiemi(decimal NovadsID)
        //{

        //    List<Arg_Adrese> pagasti_List = new List<Arg_Adrese>();

        //    pagasti_List = (from pagasts in _context.Arg_Adrese_ where pagasts.VKUR_CD == NovadsID && (pagasts.TIPS_CD == 104 || pagasts.TIPS_CD == 105) orderby pagasts.T6 ascending select pagasts).ToList();

        //    //var novadi = _context.Arg_Adrese_.Where(n => n.tips_cd == 113 && n.STATUSS == "EKS" || n.tips_cd == 104 && n.STATUSS == "EKS").ToList();

        //    return pagasti_List;

        //}

        //XLS faila vajadzībām
        [HttpGet]
        [Route("PagastiCiemi/NovadsID={NovadsID}")]
        public async Task<ActionResult<List<Arg_AdreseDTO>>> GetPagastiCiemi(decimal NovadsID) {
            //iegūst novadus 
            /*var adreses = await _context.Arg_Adrese_
                 .Where(n => n.TIPS_CD == 105 && n.STATUSS == "EKS" && n.VKUR_CD == NovadsID)
                 .Include(c => c.Arg_AdreseCiemi)
                 //.OrderBy(n => n.STD)
                //.AsNoTracking()
                .ToListAsync();*/

            var adreses = await (from s in _context.Arg_Adrese_.Include(s => s.Arg_AdreseCiemi) where s.TIPS_CD == 105 && s.STATUSS == "EKS" && s.VKUR_CD == NovadsID orderby s.T6 ascending select s).ToListAsync();

            var adresesDTOs =
                _mapper.Map
                <List<Arg_AdreseDTO>>
                (adreses);

            return adresesDTOs;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<Arg_AdreseDTO>>> Filter([FromQuery] FilterArg_AdreseDTO filterArg_AdreseDTO)
        {


            var adreseQueryable = _context.Arg_Adrese_
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterArg_AdreseDTO.STD))
            {
                adreseQueryable = adreseQueryable.Where(x => x.STD.Contains(filterArg_AdreseDTO.STD));
            }

            if (filterArg_AdreseDTO.TIPS_CD != 0)
            {
                adreseQueryable = adreseQueryable.Where(o => o.TIPS_CD.Equals(filterArg_AdreseDTO.TIPS_CD));

            }

            //if (filterArg_AdreseDTO.ADR_CD != 0)
            //{
            //    adreseQueryable = adreseQueryable.Where(o => o.ADR_CD.Equals(filterArg_AdreseDTO.ADR_CD) && o.dat_beig != null);

            //}

            if (filterArg_AdreseDTO.VKUR_CD != 0)
            {
                adreseQueryable = adreseQueryable.Where(o => o.VKUR_CD.Equals(filterArg_AdreseDTO.VKUR_CD));

            }

            if (!string.IsNullOrWhiteSpace(filterArg_AdreseDTO.STATUSS))
            {
                adreseQueryable = adreseQueryable.Where(o => o.STATUSS.Equals(filterArg_AdreseDTO.STATUSS));
            }

            //https://localhost:44302/api/adreses/filter?DAT_SAK=2011-07-07&STD=dzirn

                    /*
                if (value.HasValue)
                {
                    Console.WriteLine(value.Value);
                }
                else
                {
                    Console.WriteLine(0);
                }*/

            if (filterArg_AdreseDTO.DAT_SAK != DateTime.MinValue)

            {
                adreseQueryable = adreseQueryable.Where(o => o.DAT_SAK.Date.Equals(filterArg_AdreseDTO.DAT_SAK));
            }

            if (filterArg_AdreseDTO.DAT_MOD != DateTime.MinValue) // visi null datumi lasās kā '01.01.0001 00:00:00' kas ir arī MinValue
            {
               
                adreseQueryable = adreseQueryable.Where(o => o.dat_mod.Date.Equals(filterArg_AdreseDTO.DAT_MOD));
                // dat_mod ielasot null nestrādā, ielaspt DaeTime strādā.
            }

            //if (filterArg_AdreseDTO.DAT_BEIG != DateTime.MinValue)
            //{

            //    adreseQueryable = adreseQueryable.Where(o => o.dat_beig.Date.Equals(filterArg_AdreseDTO.DAT_BEIG));
            //}
            Console.WriteLine("arg_Adrese.ADR_CD: " + filterArg_AdreseDTO.ADR_CD);
            Console.WriteLine("arg_Adrese.STD: " + filterArg_AdreseDTO.STD);
            Console.WriteLine("arg_Adrese.tips_cd: " + filterArg_AdreseDTO.TIPS_CD);
            Console.WriteLine("arg_Adrese.STATUSS: " + filterArg_AdreseDTO.STATUSS);
            Console.WriteLine("arg_Adrese.DAT_SAK: " + filterArg_AdreseDTO.DAT_SAK);

            var adreses = await adreseQueryable//.Where(o => o.dat_mod.Date.Equals(filterArg_AdreseDTO.DAT_MOD))
                .Include(q => q.Art_KonstTips)
                .Include(q => q.Art_KonstStatuss)
                .ToListAsync();

            var adresesSorted = adreses.OrderBy(n => n.ADR_CD).ToList(); //vajag sortot jo asinhroni liekot adreses lista katra adrese ne vienmer bus vienaa un tada pasa pozicijaa
            return _mapper.Map<List<Arg_AdreseDTO>>(adresesSorted);
        }

        [HttpGet("filterPaginated")]
        public async Task<ActionResult<List<Arg_AdreseDTO>>> FilterPaginated([FromQuery] FilterArg_AdreseDTO filterArg_AdreseDTO, int page, int pageSize) {
            var adreseQueryable = _context.Arg_Adrese_
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterArg_AdreseDTO.STD)) {
                adreseQueryable = adreseQueryable.Where(x => x.STD.Contains(filterArg_AdreseDTO.STD));
            }

            if (filterArg_AdreseDTO.TIPS_CD != 0) {
                adreseQueryable = adreseQueryable.Where(o => o.TIPS_CD.Equals(filterArg_AdreseDTO.TIPS_CD));

            }

            //if (filterArg_AdreseDTO.ADR_CD != 0)
            //{
            //    adreseQueryable = adreseQueryable.Where(o => o.ADR_CD.Equals(filterArg_AdreseDTO.ADR_CD) && o.dat_beig != null);

            //}

            //if (filterArg_AdreseDTO.VKUR_CD != 0) {
            //    adreseQueryable = adreseQueryable.Where(o => o.VKUR_CD.Equals(filterArg_AdreseDTO.VKUR_CD));
            //} else if (filterArg_AdreseDTO.VKUR_CD_NOV != 0) {
            //    adreseQueryable = adreseQueryable.Where(o => o.VKUR_CD.Equals(filterArg_AdreseDTO.VKUR_CD_NOV));
            //}

            adreseQueryable = adreseQueryable.Where(o => o.VKUR_CD.Equals(
                filterArg_AdreseDTO.VKUR_CD != 0 ? filterArg_AdreseDTO.VKUR_CD : filterArg_AdreseDTO.VKUR_CD_NOV
                )); //ja nav selectionā izvelēts pagasts, tad atlasa no novada - iegūst datus par pagastiem

            

            if (!string.IsNullOrWhiteSpace(filterArg_AdreseDTO.STATUSS)) {
                adreseQueryable = adreseQueryable.Where(o => o.STATUSS.Equals(filterArg_AdreseDTO.STATUSS));
            }

            if (filterArg_AdreseDTO.DAT_SAK != DateTime.MinValue) {
                adreseQueryable = adreseQueryable.Where(o => o.DAT_SAK.Date.Equals(filterArg_AdreseDTO.DAT_SAK));
            }

            if (filterArg_AdreseDTO.DAT_MOD != DateTime.MinValue) // visi null datumi lasās kā '01.01.0001 00:00:00' kas ir arī MinValue
            {

                adreseQueryable = adreseQueryable.Where(o => o.dat_mod.Date.Equals(filterArg_AdreseDTO.DAT_MOD));
                // dat_mod ielasot null nestrādā, ielaspt DaeTime strādā.
            }

            //if (filterArg_AdreseDTO.DAT_BEIG != DateTime.MinValue)
            //{

            //    adreseQueryable = adreseQueryable.Where(o => o.dat_beig.Date.Equals(filterArg_AdreseDTO.DAT_BEIG));
            //}

            var adreses = await adreseQueryable//.Where(o => o.dat_mod.Date.Equals(filterArg_AdreseDTO.DAT_MOD))
                .Include(q => q.Art_KonstTips)
                .Include(q => q.Art_KonstStatuss)
                .OrderBy(n => n.ADR_CD)
                .AsNoTracking()
                .ToListAsync();

            //var adresesSorted = adreses.OrderBy(n => n.ADR_CD).ToList(); //vajag sortot jo asinhroni liekot adreses lista katra adrese ne vienmer bus vienaa un tada pasa pozicijaa

            var paginatedAdreses = await PaginatedList<Arg_Adrese>.Create(adreses, page, pageSize);

            var metadata = new {
                paginatedAdreses.PageIndex,
                paginatedAdreses.TotalPages,
                paginatedAdreses.ElementCount,
                paginatedAdreses.HasNextPage,
                paginatedAdreses.HasPreviousPage
            };

            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(metadata));

            return _mapper.Map<List<Arg_AdreseDTO>>(paginatedAdreses);
        }


        // PUT: api/Adreses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArg_Adrese(decimal id, Arg_Adrese arg_Adrese)
        {
            if (id != arg_Adrese.ADR_CD)
            {
                return BadRequest();
            }

            _context.Entry(arg_Adrese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Arg_AdreseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adreses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Arg_Adrese>> PostArg_Adrese(Arg_Adrese arg_Adrese)
        {


            _context.Arg_Adrese_.Add(arg_Adrese);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Arg_AdreseExists(arg_Adrese.ADR_CD))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArg_Adrese", new
            {
                id = arg_Adrese.ADR_CD
            }, arg_Adrese);
        }

        // DELETE: api/Adreses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Arg_Adrese>> DeleteArg_Adrese(decimal id)
        {
            var arg_Adrese = await _context.Arg_Adrese_.FindAsync(id);
            if (arg_Adrese == null)
            {
                return NotFound();
            }

            _context.Arg_Adrese_.Remove(arg_Adrese);
            await _context.SaveChangesAsync();

            return arg_Adrese;
        }

        private bool Arg_AdreseExists(decimal id)
        {
            return _context.Arg_Adrese_.Any(e => e.ADR_CD == id);
        }
    }
}