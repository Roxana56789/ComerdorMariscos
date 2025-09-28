using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComedorMariscos.DTOs;
using ComedorMariscos.Interfaces;
using ComedorMariscos.Servicios;

namespace ComedorMariscos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔒 protege todos los endpoints
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;

        // ✅ Constructor que inyecta el servicio
        public CategoriaController(CategoriaService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/CategoriaRJ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAll()
        {
            var categorias = await _service.GetAllAsync();
            return Ok(categorias);
        }

        // GET: api/CategoriaRJ/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound();

            return Ok(categoria);
        }

        // POST: api/CategoriaRJ
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> Create(CategoriaCreateDTO dto)
        {
            var nuevaCategoria = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevaCategoria.Id }, nuevaCategoria);
        }

        // PUT: api/CategoriaRJ/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoriaCreateDTO dto)
        {
            var actualizado = await _service.UpdateAsync(id, dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
