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
    public class ArtNLietasController : ControllerBase
    {
        private readonly DataContextAR _context;

        public ArtNLietasController(DataContextAR context)
        {
            _context = context;
        }

        // GET: api/ArtNLietas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art_NLieta>>> GetArt_NLieta()
        {
            return await _context.Art_NLieta.Take(100).ToListAsync();
        }

        // GET: api/ArtNLietas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Art_NLieta>> GetArt_NLieta(decimal id)
        {
            var art_NLieta = await _context.Art_NLieta.FindAsync(id);

            if (art_NLieta == null)
            {
                return NotFound();
            }

            return art_NLieta;
        }

        [HttpGet("{id}")]
        [Route("NLbyPagastsID/{id}")]
        public async Task<ActionResult<IEnumerable<Art_NLieta>>> NLbyPagastsID(decimal id) {
            var lietas = await _context.Art_NLieta.Where(a => a.VKUR_CD == id).ToListAsync();

            if (lietas == null) {
                return NotFound();
            }

            lietas = lietas.OrderBy(n => n.KODS).ToList();

            return lietas;
        }


        // PUT: api/ArtNLietas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt_NLieta(decimal id, Art_NLieta art_NLieta)
        {
            if (id != art_NLieta.KODS)
            {
                return BadRequest();
            }

            _context.Entry(art_NLieta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Art_NLietaExists(id))
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

        // POST: api/ArtNLietas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Art_NLieta>> PostArt_NLieta(Art_NLieta art_NLieta)
        {
            _context.Art_NLieta.Add(art_NLieta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Art_NLietaExists(art_NLieta.KODS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArt_NLieta", new { id = art_NLieta.KODS }, art_NLieta);
        }

        // DELETE: api/ArtNLietas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Art_NLieta>> DeleteArt_NLieta(decimal id)
        {
            var art_NLieta = await _context.Art_NLieta.FindAsync(id);
            if (art_NLieta == null)
            {
                return NotFound();
            }

            _context.Art_NLieta.Remove(art_NLieta);
            await _context.SaveChangesAsync();

            return art_NLieta;
        }

        private bool Art_NLietaExists(decimal id)
        {
            return _context.Art_NLieta.Any(e => e.KODS == id);
        }
    }
}
