using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcWebSiteAPI.Data;
using PcWebSiteAPI.Models;

namespace PcWebSiteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BrandsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brand>>> GetProducts()
    {
        var brands = await _context.Products.ToListAsync();

        return Ok(brands);
    }
}
