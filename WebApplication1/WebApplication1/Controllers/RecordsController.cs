using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Model.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class RecordsController : ControllerBase
{
    
    private readonly IRecordService _service;

    public RecordsController(IRecordService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int? languageId, [FromQuery] int? taskId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var records = await _service.GetRecordsAsync(languageId, taskId, from, to);
        return Ok(records);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRecordRequestDto request)
    {
        var result = await _service.CreateRecordAsync(request);
        if (!result.Success)
            return BadRequest(result.Message);

        return Created("", result.Message);
    }

}