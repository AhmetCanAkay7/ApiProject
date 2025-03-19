using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChefsController : ControllerBase
{
    private readonly ApiContext _context;

    public ChefsController(ApiContext context)
    {
        _context = context;
    }
    
    [HttpGet(nameof(GetAll))]
    public IActionResult GetAll()
    {
        var chefs = _context.Chefs.ToList();
        return Ok(chefs);
    }
    
    [HttpGet(nameof(GetById))]
    public IActionResult GetById(int id)
    {
        var chef = _context.Chefs.Find(id);
        if (chef == null)
        {
            return NotFound("Chef not found");
        }
        return Ok(chef);
    }

    [HttpPost(nameof(Insert))]
    public IActionResult Insert(Chef chef)
    {
        _context.Chefs.Add(chef);
        _context.SaveChanges();
        return Ok("Chef was added");
    }
    
    [HttpDelete(nameof(Delete))]
    public IActionResult Delete(int chefId)
    {
        var chefToDelete = _context.Chefs.Find(chefId);
        if (chefToDelete == null)
        {
            return NotFound("Chef not found");
        }
        _context.Chefs.Remove(chefToDelete);
        _context.SaveChanges();
        return Ok("Chef was deleted");
    }

    [HttpPut(nameof(Update))]
    public IActionResult Update(Chef chef)
    {
        _context.Chefs.Update(chef);
        _context.SaveChanges();
        return Ok("Chef was updated");
    }
    
    
}