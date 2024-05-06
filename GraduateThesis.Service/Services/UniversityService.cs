﻿using AutoMapper;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class UniversityService : GenericService<University, UniversityDto>, IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        public UniversityService(IGenericRepository<University> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IUniversityRepository universityRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _universityRepository = universityRepository;
        }

        // Overload
        public async Task<CustomResponseDto<UniversityDto>> AddAsync(CreateUniversityDto dto)
        {
            var newEntity = _mapper.Map<University>(dto);
            await _universityRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var addedDto = _mapper.Map<UniversityDto>(newEntity);

            return CustomResponseDto<UniversityDto>.Success((int)HttpStatusCode.Created, addedDto);
        }

        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(UpdateUniversityDto dto)
        {
            var entity = _mapper.Map<University>(dto);
            _universityRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }
    }
}
