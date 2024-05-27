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
    public class MemberRepository : GenericRepository<ClubAppUser>, IMemberRepository
    {
        public MemberRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ClubAppUser> GetClubAppUserById(string id)
        {
            return await _dbContext.ClubAppUsers.FirstOrDefaultAsync(x => x.AppUserId == id);
        }

        public async Task<bool> isUserMemberOfSpecifiedClub(string userId,int clubId)
        {
            return await _dbContext.ClubAppUsers.AnyAsync(x => x.ClubId == clubId && x.AppUserId == userId);
        }

        public IQueryable<ClubAppUser> GetMemberClubs(string id)
        {
            return _dbContext.ClubAppUsers.AsNoTracking()
                .Where(x => x.AppUserId == id)
                .Include(ca => ca.Club)
                .AsQueryable();
        }

        public void Remove(string userId, int clubId)
        {
            var clubAppUser = _dbContext.ClubAppUsers.FirstOrDefault(c => c.AppUserId == userId && c.ClubId == clubId);
            _dbContext.Remove(clubAppUser);
        }
    }
}
