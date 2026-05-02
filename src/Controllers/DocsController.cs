// ASR-SAST-006: path traversal — Path.Combine with user input, no normalisation check.
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("docs")]
public class DocsController : ControllerBase
{
    private const string Root = "/var/assurix/docs";

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        var path = Path.Combine(Root, name);
        if (!System.IO.File.Exists(path)) return NotFound();
        return PhysicalFile(path, "application/octet-stream");
    }
}
