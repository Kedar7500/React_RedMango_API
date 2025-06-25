using Microsoft.EntityFrameworkCore;
using RedMango_API.Data;
using RedMango_API.Models.Domain;

namespace RedMango_API.Repository
{
    public class SQLMenuItemRepository : IMenuItemRepository
    {
        private readonly RedMangoDbContext dbContext;

        public SQLMenuItemRepository(RedMangoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<MenuItem>> GetMenuItems()
        {
            return await dbContext.menuItems.ToListAsync();
        }
    }
}
