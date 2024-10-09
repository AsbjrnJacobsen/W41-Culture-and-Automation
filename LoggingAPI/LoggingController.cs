using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoggingAPI;

[ApiController]
[Route("api/[controller]")]
public class LoggingController : Controller
{
    private readonly LoggingDbContext _context;
    public LoggingController(LoggingDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Takes a Log object and inserts it into the logging database.
    /// </summary>
    /// <param name="log">The Log object to create.</param>
    /// <returns>Status code 200/OK on successful log creation.</returns>
    [HttpPost("PostLog")]
    public async Task<IActionResult> PostLog([FromBody] Log log)
    {
        await _context.Logs.AddAsync(log);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    
    /// <summary>
    /// This provides an example json response with indication of how the log should be formatted.
    /// </summary>
    /// <returns>Example Log</returns>
    [HttpGet("GetExample")]
    public IActionResult GetExample()
    {
        var example = new Log()
        {
            Id = 0,
            Severity = SeverityLevel.Information,
            Message = "This is a message",
            SystemIdentifier = Guid.NewGuid(),
            SessionIdentifier = Guid.NewGuid()
        };
        return Ok(example);
    }

    /// <summary>
    /// Returns all Logs in the database
    /// </summary>
    /// <returns>All Logs</returns>
    [HttpGet("GetLogs")]
    public async Task<IActionResult> GetLogs()
    {
        return Ok(await _context.Logs.ToListAsync());
    }
}