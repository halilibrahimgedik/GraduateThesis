using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Repository.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        public ClubRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Club>> GetActiveClubsByUniversityAsync(int universityId)
        {
            return await _dbContext.Clubs
                .AsNoTracking()
                .Where(c => c.ClubUniversityId == universityId && c.IsActive)
                .ToListAsync();
        }

        public async Task<Club> GetClubByIdWithCategories(int id)
        {
            return await _dbContext.Clubs.Include(c => c.ClubCategories).ThenInclude(cc=>cc.Category).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubsByUniversityWithCategoriesAsync(int universityId)
        {
            return await _dbContext.Clubs.AsNoTracking()
                                        .Where(c => c.ClubUniversityId == universityId && c.IsActive)
                                        .Include(c => c.ClubCategories)
                                        .ThenInclude(cc => cc.Category)
                                        .ToListAsync();
        }
    }
}
