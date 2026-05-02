// ASR-SAST-002: BinaryFormatter.Deserialize on user-supplied bytes.
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Formatters.Binary;
#pragma warning disable SYSLIB0011

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    [HttpPost("import-config")]
    public IActionResult ImportConfig()
    {
        using var ms = new MemoryStream();
        Request.Body.CopyToAsync(ms).Wait();
        ms.Position = 0;
        var bf = new BinaryFormatter();
        var obj = bf.Deserialize(ms);                    // ASR-SAST-002
        return Ok(new { applied = obj?.GetType().Name });
    }
}
