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
    public class SubscriberRepository : GenericRepository<ClubAppUser>, ISubscriberRepository
    {
        public SubscriberRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<ClubAppUser> GetSubscriberClubs(string id)
        {
            return _dbContext.ClubAppUsers.AsNoTracking()
                .Where(x => x.AppUserId == id)
                .Include(ca => ca.Club)
                .AsQueryable();
        }

    }
}
