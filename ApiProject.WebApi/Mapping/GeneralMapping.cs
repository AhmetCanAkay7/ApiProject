using ApiProject.WebApi.DTOs;
using ApiProject.WebApi.DTOs.FeatureDtos;
using ApiProject.WebApi.DTOs.MessageDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;

namespace ApiProject.WebApi.Mapping;
//Dto ile Entityi normalde property bazında manuel olarak mapliyorduk.
//2 farklı classtan ise join ile, aynı classtan ise normal.
//AutoMapper bu işlemi sınıf bazında yapmamızı sağlar.
public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Product, ProductDto>();
        
        //Ctrl+D
        CreateMap<Message, CreateMessageDtos>().ReverseMap();
        CreateMap<Message, ResultMessageDtos>().ReverseMap();
        CreateMap<Message, UpdateMessageDtos>().ReverseMap();
        CreateMap<Message, GetByIdMessageDtos>().ReverseMap();
        
        CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
    }
}