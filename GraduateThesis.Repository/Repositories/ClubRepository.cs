﻿using GraduateThesis.Core.Dtos.ClubDtos;
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

        public async Task<Club> GetClubByIdWithCategories(int id)
        {
            return await _dbContext.Clubs.Include(c => c.ClubCategories).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubsWithCategoriesAsync()
        {
            return await _dbContext.Clubs.Include(c => c.ClubCategories).ThenInclude(cc => cc.Category).ToListAsync();
        }
    }
}
