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
    public class ClubPresidentRepository : GenericRepository<ClubPresident>, IClubPresidentRepository
    {
        public ClubPresidentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Club>> GetClubsOfPresident(string appUserId)
        {
            return await _dbContext.ClubPresidents.Where(x=>x.AppUserId == appUserId).Select(x=>x.Club).ToListAsync();
        }
    }
}
