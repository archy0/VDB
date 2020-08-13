using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VDB.Data;
using VDB.Models;

namespace VDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Art_KonstController : ControllerBase
    {
        private readonly DataContextAR _context;

        public Art_KonstController(DataContextAR context)
        {
            _context = context;
        }

        // GET: api/Art_Konst
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art_Konst>>> GetArt_Konst_()
        {
            return await _context.Art_Konst_.ToListAsync();
        }

        [Route("KODIF100")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art_Konst>>> GetArt_Konst_KODIF100()
        {
            return await _context.Art_Konst_.Where(n => n.KODIF == 100)
                .AsNoTracking()
                .ToListAsync();
        }

        [Route("AdresesStatusi")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art_Konst>>> GetArt_Konst_AdresesStatusi()
        {
            return await _context.Art_Konst_.Where(n => n.KODS == 1 || n.KODS == 2 || n.KODS == 6)
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/Art_Konst/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Art_Konst>> GetArt_Konst(decimal id)
        {
            var art_Konst = await _context.Art_Konst_.FindAsync(id);

            if (art_Konst == null)
            {
                return NotFound();
            }

            return art_Konst;
        }

        // PUT: api/Art_Konst/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt_Konst(decimal id, Art_Konst art_Konst)
        {
            if (id != art_Konst.KODS)
            {
                return BadRequest();
            }

            _context.Entry(art_Konst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Art_KonstExists(id))
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

        // POST: api/Art_Konst
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Art_Konst>> PostArt_Konst(Art_Konst art_Konst)
        {
            _context.Art_Konst_.Add(art_Konst);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Art_KonstExists(art_Konst.KODS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArt_Konst", new { id = art_Konst.KODS }, art_Konst);
        }

        // DELETE: api/Art_Konst/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Art_Konst>> DeleteArt_Konst(decimal id)
        {
            var art_Konst = await _context.Art_Konst_.FindAsync(id);
            if (art_Konst == null)
            {
                return NotFound();
            }

            _context.Art_Konst_.Remove(art_Konst);
            await _context.SaveChangesAsync();

            return art_Konst;
        }

        private bool Art_KonstExists(decimal id)
        {
            return _context.Art_Konst_.Any(e => e.KODS == id);
        }
    }
}
