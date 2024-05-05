using AutoMapper;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Club Mapping
            CreateMap<Club, ClubDto>(); 
            CreateMap<CreateClubDto, Club>(); 
            CreateMap<Club, ClubWithCategoryDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ClubCategories.Select(cc => cc.Category)));


            // Category Mapping
            CreateMap<ClubCategory, CategoryDto>();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
