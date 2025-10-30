using api_crud_mascota.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_crud_mascota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly MascotaDbContext _context;

        public MascotaController(MascotaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var listarMascotas = await _context.Mascotas.ToListAsync();
                return Ok(listarMascotas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                var mascota = await _context.Mascotas.FindAsync(id);
                if(mascota == null)
                {
                    return NotFound();
                }
                return Ok(mascota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]    
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mascota = await _context.Mascotas.FindAsync(id);
                if(mascota == null)
                {
                    return NotFound();
                }
                _context.Mascotas.Remove(mascota);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
