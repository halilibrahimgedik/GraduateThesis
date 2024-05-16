using AutoMapper;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
using GraduateThesis.Service.Exceptions;
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
        public GenericService(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(Dto dto)
        {
            var newEntity = ObjectMapper.Mapper.Map<T>(dto);

            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var createdEntity = ObjectMapper.Mapper.Map<Dto>(newEntity);

            return CustomResponseDto<Dto>.Success((int)HttpStatusCode.Created, createdEntity);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos)
        {
            var entities = ObjectMapper.Mapper.Map<IEnumerable<T>>(dtos);
            await _genericRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();

            var createdEntities = ObjectMapper.Mapper.Map<IEnumerable<Dto>>(entities);

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
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success((int)HttpStatusCode.OK, dtos);
        }

        public async Task<CustomResponseDto<Dto>> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ClientSideException("id value can not be 0 or null ...");
            }

            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"{typeof(T).Name} ({id}) not found ...");
            }

            var dto = ObjectMapper.Mapper.Map<Dto>(entity);

            return CustomResponseDto<Dto>.Success((int)HttpStatusCode.OK, dto);
        }

        public async Task<CustomResponseDto<NoDataDto>> RemoveAsync(int id)
        {
            if(id == 0)
            {
                throw new ClientSideException($"{typeof(T)} id can not be 0 ...");
            }

            var entity = await _genericRepository.GetByIdAsync(id);

            if(entity == null)
            {
                throw new NotFoundException($"{typeof(T).Name} ({id}) not found ...");
            }

            _genericRepository.Remove(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        public async Task<CustomResponseDto<NoDataDto>> RemoveRangeAsync(IEnumerable<int> ids)
        {
            var entities = await _genericRepository.Where(entity=> ids.Contains(entity.Id)).ToListAsync();
            _genericRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        public async Task<CustomResponseDto<NoDataDto>> UpdateAsync(Dto dto)
        {
            var entity = ObjectMapper.Mapper.Map<T>(dto);
            _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success((int)HttpStatusCode.NoContent);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<T, bool>> expression)
        {
            var entities = await _genericRepository.Where(expression).ToListAsync();

            var dtos = ObjectMapper.Mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success((int)HttpStatusCode.OK, dtos);
        }
    }
}
