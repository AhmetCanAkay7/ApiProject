using ApiProject.WebApi.Context;
using ApiProject.WebApi.DTOs;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApiContext _apiContext;

    public ProductsController(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }
    
   [HttpGet(nameof(GetAll))]
   public IActionResult GetAll()
   {
       var result = _apiContext.Products.ToList();
       return Ok(result);
   }
   
   [HttpGet(nameof(GetAllProductDto))]
   public IActionResult GetAllProductDto()
   {
       var result = _apiContext.Products
           .Join(_apiContext.Categories,
               product => product.CategoryId,
               category => category.CategoryId,
               (product, category) => new ProductDto
               {
                   Id = product.ProductId,
                   Name = product.ProductName,
                   CategoryName = category.CategoryName,
                   Price = product.Price,
                   Description = product.Description
               })
           .ToList();
       return Ok(result);
   }
    
   [HttpGet(nameof(GetById))]
   public IActionResult GetById(int id)
   {
       var result = _apiContext.Products.Find(id);
         if (result == null)
             return NotFound("Product not found");
         else
             return Ok(result);
   }
   
   [HttpPost(nameof(Insert))]
   public IActionResult Insert(Product product)
   {
       _apiContext.Products.Add(product);
       _apiContext.SaveChanges();
       return Ok("Product was added");
   }
   
    [HttpDelete(nameof(Delete))]
    public IActionResult Delete(int productId)
    {
        var productToDelete = _apiContext.Products.Find(productId);
        if (productToDelete == null)
        {
            return NotFound("Product not found");
        }
        _apiContext.Products.Remove(productToDelete);
        _apiContext.SaveChanges();
        return Ok("Product was deleted");
    }
    
    [HttpPut(nameof(Update))]
    public IActionResult Update(Product product)
    {
        _apiContext.Products.Update(product);
        _apiContext.SaveChanges();
        return Ok("Product was updated");
    }
}