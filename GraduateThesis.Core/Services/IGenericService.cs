using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IGenericService<T,Dto> where T : BaseEntity where Dto : class
    {
        Task<CustomResponseDto<Dto>> GetByIdAsync(int id);
        Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync();
        Task<CustomResponseDto<Dto>> AddAsync(Dto dto);
        Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos);
        Task<CustomResponseDto<NoDataDto>> UpdateAsync(Dto dto);
        Task<CustomResponseDto<NoDataDto>> RemoveAsync(int id);
        Task<CustomResponseDto<NoDataDto>> RemoveRange(IEnumerable<int> ids);

        Task<CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<T, bool>> expression);
        Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
