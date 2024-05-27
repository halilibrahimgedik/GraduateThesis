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
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task ApplyForClub(Application application)
        {
            await _dbContext.Applications.AddAsync(application);
        }

        public async Task<List<Application>> GetClubApplicationsByClubId(int clubId)
        {
            return await _dbContext.Applications.Where(x=>x.ClubId == clubId).ToListAsync();
        }
    }
}
