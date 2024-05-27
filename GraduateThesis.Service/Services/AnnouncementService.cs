using GraduateThesis.Core.Dtos.AnnouncementDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class AnnouncementService : GenericService<Announcement, AnnouncementDto>, IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementService(IGenericRepository<Announcement> genericRepository, IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository) : base(genericRepository, unitOfWork)
        {
            _announcementRepository = announcementRepository;
        }


        public async Task<CustomResponseDto<AnnouncementDto>> AddAsync(CreateAnnouncementDto createAnnouncementDto)
        {
            var announcment = ObjectMapper.Mapper.Map<Announcement>(createAnnouncementDto);

            await _announcementRepository.AddAsync(announcment);
            await _unitOfWork.CommitAsync();

            var announcementDto = ObjectMapper.Mapper.Map<AnnouncementDto>(announcment);

            return CustomResponseDto<AnnouncementDto>.Success(StatusCodes.Status201Created, announcementDto);
        }
    }
}
