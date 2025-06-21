using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
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
    [Route("{id}")]
    public async Task<ActionResult<Record>> GetRecordAsync([FromRoute] string id)
    {
        return Ok();
    }

}