using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s34434.DTOs;
using PJATK_APBD_Cw7_s34434.Services;

namespace PJATK_APBD_Cw7_s34434.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pcService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await _pcService.GetComponentsAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _pcService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _pcService.UpdateAsync(id, dto);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _pcService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}