using HSLRushHour.Backend.Models;
using HSLRushHour.Backend.Models.Dtos;
using HSLRushHour.Backend.Models.Dtos.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HSLRushHour.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisruptionsController : ControllerBase
{
    private readonly ILogger<DisruptionsController> _logger;
    private readonly HSLRushHourDbContext _context;

    public DisruptionsController(ILogger<DisruptionsController> logger, HSLRushHourDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<DisruptionDto>> getAll()
    {
        return await _context.Disruptions
                        .Select(x => x.toDto())
                        .ToListAsync();
    }

}
