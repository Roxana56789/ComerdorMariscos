using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComedorMariscos.DTOs;
using ComedorMariscos.Interfaces;
using ComedorMariscos.Servicios;
using ComedorMariscos.DTOs.CategoriaDTOs;

namespace ComedorMariscos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     // 🔒 protege todos los endpoints
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
           => Ok(await _service.GetAllAsync());
        [HttpGet("{Id_Categoria:int}")]
        public async Task<IActionResult> GetById(int Id_Categoria)
        {
            var item = await _service.GetByIdAsync(Id_Categoria);
            return item is null ? NotFound() : Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id_Categoria = created.Id }, created);
        }
        [HttpPut("{Id_Categoria}")]
        public async Task<IActionResult> Update(int Id_Categoria, [FromBody] CategoriaActualizarDTO dto)
        {
            var ok = await _service.UpdateAsync(Id_Categoria, dto);
            return ok ? NoContent() : NotFound();
        }
        [HttpDelete("{Id_Categoria:int}")]
        public async Task<IActionResult> Delete(int Id_Categoria)
        {
            var ok = await _service.DeleteAsync(Id_Categoria);
            return ok ? NoContent() : NotFound();
        }
    }
}
