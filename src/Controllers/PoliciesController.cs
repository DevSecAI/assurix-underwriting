// ASR-SAST-001: SqlCommand built from f-string.
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

[ApiController]
[Route("policies")]
public class PoliciesController : ControllerBase
{
    private readonly string _conn;
    public PoliciesController(IConfiguration cfg) { _conn = cfg.GetConnectionString("Default")!; }

    [HttpGet]
    public IActionResult Search([FromQuery] string status, [FromQuery] string broker)
    {
        using var c = new SqlConnection(_conn);
        c.Open();
        // ASR-SAST-001: status + broker concatenated into SQL.
        using var cmd = new SqlCommand(
            $"SELECT id, holder_name, premium FROM policies WHERE status='{status}' AND broker='{broker}'", c);
        using var r = cmd.ExecuteReader();
        var rows = new List<object>();
        while (r.Read()) rows.Add(new { id = r[0], holder = r[1], premium = r[2] });
        return Ok(rows);
    }
}
