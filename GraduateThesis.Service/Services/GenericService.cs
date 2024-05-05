using AutoMapper;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class GenericService<T, Dto> : IGenericService<T, Dto> where T : BaseEntity where Dto : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public GenericService(IGenericRepository<T> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(Dto dto)
        {
            var newEntity = _mapper.Map<T>(dto);

            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var createdEntity = _mapper.Map<Dto>(newEntity);

            return CustomResponseDto<Dto>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos)
        {
            var entities = _mapper.Map<IEnumerable<T>>(dtos);
            await _genericRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();

            var createdEntities = _mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success((int)HttpStatusCode.Created, createdEntities);
        }

        public async Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _genericRepository.AnyAsync(expression);

            return CustomResponseDto<bool>.Success((int)HttpStatusCode.OK,result);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAll().ToListAsync();
            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success((int)HttpStatusCode.OK, dtos);
        }

        public async Task<CustomResponseDto<Dto>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            var dto = _mapper.Map<Dto>(entity);

            return CustomResponseDto<Dto>.Success((int)HttpStatusCode.OK, dto);
        }

        public async Task<CustomResponseDto<NoDataDto>> RemoveAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            _genericRepository.Remove(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        public async Task<CustomResponseDto<NoDataDto>> RemoveRange(IEnumerable<int> ids)
        {
            var entities = await _genericRepository.Where(entity=> ids.Contains(entity.Id)).ToListAsync();
            _genericRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(Dto dto)
        {
            var entity = _mapper.Map<T>(dto);
            _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<T, bool>> expression)
        {
            var entities = await _genericRepository.Where(expression).ToListAsync();

            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success((int)HttpStatusCode.OK, dtos);
        }
    }
}
