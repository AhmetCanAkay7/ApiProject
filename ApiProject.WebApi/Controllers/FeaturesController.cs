using ApiProject.WebApi.Context;
using ApiProject.WebApi.DTOs.FeatureDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController:ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ApiContext _apiContext;
    
    public FeaturesController(IMapper mapper, ApiContext apiContext)
    {
        _mapper = mapper;
        _apiContext = apiContext;
    }

    [HttpGet(nameof(GetAll))]
    public IActionResult GetAll()
    {
        var values = _apiContext.Features.ToList();
        List<ResultFeatureDto> result = _mapper.Map<List<ResultFeatureDto>>(values);
        return Ok(result);
    }

    [HttpPost(nameof(CreateFeature))]
    public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
    {
        Feature feature = _mapper.Map<Feature>(createFeatureDto);
        _apiContext.Features.Add(feature);
        _apiContext.SaveChanges();
        return Ok("Feature created successfully.");
    }

    [HttpDelete(nameof(DeleteFeature))]
    public IActionResult DeleteFeature(int id)
    {
        var value = _apiContext.Features.Find(id);
        _apiContext.Features.Remove(value);
        _apiContext.SaveChanges();
        return Ok("Feature deleted successfully.");
    }
    
    [HttpPut(nameof(UpdateFeature))]
    public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        var value = _mapper.Map<Feature>(updateFeatureDto);
        _apiContext.Features.Update(value);
        _apiContext.SaveChanges();
        return Ok("Feature updated successfully.");
        
    }

    [HttpGet(nameof(GetById))]
    public IActionResult GetById(int id)
    {
        var value = _apiContext.Features.Find(id);
        return Ok(_mapper.Map<GetByIdFeatureDto>(value));
    }
}
