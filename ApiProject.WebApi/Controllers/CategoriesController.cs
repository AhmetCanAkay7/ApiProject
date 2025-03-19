using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
// Normalde controllera bir istek geldiğinde; controller business katmanını, business dataAccess katmanını
// kullanır. veritabanıyla etkileşim context nesnesi üzerinden yapılır. DAL sınıfları context nesnesini
// kullanır. Burada katmanlı bir yapı olmadan direkt context nesnesi üzerinden veritabanına erişim yapıldı.
// Bir controllerda bir attribute birden fazla kez kullanılamaz.
public class CategoriesController : ControllerBase
{
    private readonly ApiContext _context;

    public CategoriesController(ApiContext context)
    {
        _context = context;
    }
    [HttpGet(nameof(GetAll))]
    public IActionResult GetAll()
    {
        var categories = _context.Categories.ToList();
        return Ok(categories);
    }

    [HttpGet(nameof(GetById))]
    public IActionResult GetById(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound("Category not found");
        }
        return Ok(category);
    }
        
    [HttpPost(nameof(Insert))]
    public IActionResult Insert(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return Ok("Category was added");
    }

    [HttpDelete(nameof(Delete))]
    public IActionResult Delete(int categoryId)
    {
        var categoryToDelete = _context.Categories.Find(categoryId);
        if (categoryToDelete == null)
        {
            return NotFound("Category not found");
        }
        _context.Categories.Remove(categoryToDelete);
        _context.SaveChanges();
        return Ok("Category was deleted");
    }

    [HttpPut(nameof(Update))]
    public IActionResult Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges(); 
        return Ok("Category was updated");
    }
        
        
        
}