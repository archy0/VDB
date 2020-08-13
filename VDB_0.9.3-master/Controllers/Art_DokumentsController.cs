using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public class Art_DokumentsController : ControllerBase
    {
        private readonly DataContextAR _context;
        private readonly ILogger<Art_DokumentsController> _logger;
        private readonly IMapper _mapper;

        public Art_DokumentsController(
                      ILogger<Art_DokumentsController> logger,
                     DataContextAR context,
                     IMapper mapper
            )
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Art_Dokuments
        [HttpGet]
        public async Task<ActionResult<List<Art_DokumentsDTO>>> GetArt_Dokuments_(int page, int pageSize) {

            var dokumenti = await PaginatedList<Art_Dokuments>.Create(
                await _context.Art_Dokuments_.OrderBy(n => n.ID).AsNoTracking().ToListAsync(), 
                page, 
                pageSize
            );

            var metadata = new {
                dokumenti.PageIndex,
                dokumenti.TotalPages,
                dokumenti.ElementCount,
                dokumenti.HasNextPage,
                dokumenti.HasPreviousPage
            };

            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(metadata));

            return _mapper.Map<List<Art_DokumentsDTO>>(dokumenti);
        }

        [HttpGet("{id}")]
        [Route("GetDokumenti/{id}")]
        public async Task<ActionResult<List<Art_DokumentsDTO>>> DokumentuAtlase(decimal pagastsID) {
            Console.WriteLine("called DokumentuAtlase");
            var dokumenti = await _context.Art_Dokuments_
                .Include(a => a.Art_Dok_Saite).ThenInclude(a => a.Arg_Adrese)
                .Where(a => a.Art_Dok_Saite.Where(b => b.Arg_Adrese.VKUR_CD == pagastsID) != null)
                .OrderBy(a => a.ID)
                .Take(100)
                .AsNoTracking()
                .ToListAsync();

            if (dokumenti == null) {
                return NotFound();
            } else return _mapper.Map<List<Art_DokumentsDTO>>(dokumenti);
        }



        //// GET: api/Art_Dokuments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Art_Dokuments>> GetArt_Dokuments(decimal id)
        //{
        //    var art_Dokuments = await _context.Art_Dokuments_.FindAsync(id);

        //    if (art_Dokuments == null)
        //    {
        //        return NotFound();
        //    }

        //    return art_Dokuments;
        //}

        // GET: api/Art_Dokuments/5
        [Route("Detalas/{id}")]
        [HttpGet("{id}", Name = "getDokuments")]
        public async Task<ActionResult<Art_DokumentsDetailsDTO>> GetArt_Dokuments(decimal id)
        {
            var art_Dokuments = await _context.Art_Dokuments_
                .Include(z => z.Art_Dok_Saite).ThenInclude(z => z.Arg_Adrese).ThenInclude(z => z.Art_KonstStatuss)
                .Include(z => z.Art_Dok_Saite).ThenInclude(z => z.Arg_Adrese).ThenInclude(z => z.Art_KonstTips)
                .FirstOrDefaultAsync(z => z.ID == id);

            if (art_Dokuments == null) {
                return NotFound();
            }

            var art_DokumentsDetailsDTO =
            _mapper
            .Map
            <Art_DokumentsDetailsDTO>
            (art_Dokuments);

            return art_DokumentsDetailsDTO;
        }

        // PUT: api/Art_Dokuments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt_Dokuments(decimal id, Art_Dokuments art_Dokuments)
        {
            if (id != art_Dokuments.ID)
            {
                return BadRequest();
            }

            _context.Entry(art_Dokuments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Art_DokumentsExists(id))
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

        // POST: api/Art_Dokuments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Art_Dokuments>> PostArt_Dokuments(Art_Dokuments art_Dokuments)
        {
            _context.Art_Dokuments_.Add(art_Dokuments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Art_DokumentsExists(art_Dokuments.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArt_Dokuments", new { id = art_Dokuments.ID }, art_Dokuments);
        }

        // DELETE: api/Art_Dokuments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Art_Dokuments>> DeleteArt_Dokuments(decimal id)
        {
            var art_Dokuments = await _context.Art_Dokuments_.FindAsync(id);
            if (art_Dokuments == null)
            {
                return NotFound();
            }

            _context.Art_Dokuments_.Remove(art_Dokuments);
            await _context.SaveChangesAsync();

            return art_Dokuments;
        }

        private bool Art_DokumentsExists(decimal id)
        {
            return _context.Art_Dokuments_.Any(e => e.ID == id);
        }
    }
}
