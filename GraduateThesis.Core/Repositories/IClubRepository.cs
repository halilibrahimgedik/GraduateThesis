using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Repositories
{
    public interface IClubRepository : IGenericRepository<Club> 
    {
        Task<IEnumerable<Club>> GetActiveClubsByUniversityAsync(int universityId);
        Task<Club> GetClubByIdWithCategories(int id);

        Task<IEnumerable<Club>> GetClubsByUniversityWithCategoriesAsync(int universityId);
    }
}
