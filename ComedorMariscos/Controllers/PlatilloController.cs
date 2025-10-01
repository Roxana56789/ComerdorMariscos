using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.PlatilloDTOs;
using ComedorMariscos.Interfaces;
using ComedorMariscos.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComedorMariscos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class PlatilloController : ControllerBase
    {
        private readonly IPlatilloService _service;
        public PlatilloController(IPlatilloService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
           => Ok(await _service.GetAllAsync());

        [HttpGet("{Id_Platillo:int}")]
        public async Task<IActionResult> GetById(int Id_Platillo)
        {
            var item = await _service.GetByIdAsync(Id_Platillo);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlatilloCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id_Platillo = created.Id }, created);
        }
        [HttpPut("{Id_Platillo}")]
        public async Task<IActionResult> Update(int Id_Platillo, [FromBody] PlatilloActualizarDTO dto)
        {
            var ok = await _service.UpdateAsync(Id_Platillo, dto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{Id_Platillo:int}")]
        public async Task<IActionResult> Delete(int Id_Platillo)
        {
            var ok = await _service.DeleteAsync(Id_Platillo);
            return ok ? NoContent() : NotFound();
        }
    }
}

