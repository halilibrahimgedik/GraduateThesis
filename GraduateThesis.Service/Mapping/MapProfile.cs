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
            // ! Club Mapping
            CreateMap<Club, ClubDto>();

            CreateMap<CreateClubDto, Club>();

            CreateMap<Club, ClubWitCategoryIdsDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ClubCategories.Select(cc => cc.CategoryId).ToList()));

            CreateMap<Club, ClubsWithCategoriesDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ClubCategories.Select(cc => new CategoryDto() { 
                    Id = cc.CategoryId, 
                    CategoryName = cc.Category.CategoryName, 
                    CreatedDate = cc.Category.CreatedDate 
                })));



            // ! Category Mapping

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<CreateCategoryDto, Category>();

            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Category, CategoryWithClubsDto>()
                .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => src.ClubCategories.Select(cc => new ClubDto()
                {
                    Id = cc.ClubId,
                    ClubName = cc.Club.ClubName,
                    ClubSummary = cc.Club.ClubSummary,
                    ClubPhoto = cc.Club.ClubPhoto,
                    CreatedDate = cc.Club.CreatedDate,
                    IsClubActive = cc.Club.IsClubActive
                })));

        }
    }
}
