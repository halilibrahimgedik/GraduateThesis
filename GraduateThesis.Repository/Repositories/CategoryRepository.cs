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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids)
        {
            return await _dbContext.Categories.Where(c=>ids.Contains(c.Id)).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdWithClubsAsync(int id)
        {
            return await _dbContext.Categories.Include(category => category.ClubCategories)
                                .ThenInclude(cc => cc.Club)
                                .FirstOrDefaultAsync(category=>category.Id == id);
        }
    }
}
