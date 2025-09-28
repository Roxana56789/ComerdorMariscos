using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.PlatilloDTOs;
using ComedorMariscos.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComedorMariscos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔒 protege todos los endpoints
    public class PlatilloController : ControllerBase
    {
        private readonly PlatilloService _service;

        // ✅ Constructor que inyecta el servicio
        public PlatilloController(PlatilloService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/Platillo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatilloDTO>>> GetAll()
        {
            var platillos = await _service.GetAllAsync();
            return Ok(platillos);
        }

        // GET: api/Platillo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatilloDTO>> GetById(int id)
        {
            var platillo = await _service.GetByIdAsync(id);
            if (platillo == null) return NotFound();

            return Ok(platillo);
        }

        // POST: api/Platillo
        [HttpPost]
        public async Task<ActionResult<PlatilloDTO>> Create(PlatilloCreateDTO dto)
        {
            var nuevoPlatillo = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPlatillo.Id }, nuevoPlatillo);
        }

        // PUT: api/Platillo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PlatilloCreateDTO dto)
        {
            var actualizado = await _service.UpdateAsync(id, dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        // DELETE: api/Platillo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}

