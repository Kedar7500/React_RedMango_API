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

        public async Task<MenuItem> CreateMenuItem(MenuItem menuItem)
        {
            await dbContext.menuItems.AddAsync(menuItem);
            await dbContext.SaveChangesAsync();
            return menuItem;
        }

        public async Task<MenuItem> DeleteMenuItem(int id)
        {
            // getting menuItem by id
            var menuItem = await dbContext.menuItems.FirstOrDefaultAsync(x => x.Id == id);

            dbContext.menuItems.Remove(menuItem);
            await dbContext.SaveChangesAsync();

            return menuItem;
        }

        public async Task<MenuItem> GetMenuItem(int id)
        {
            // getting menuitem by id
            return await dbContext.menuItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            return await dbContext.menuItems.ToListAsync();
        }

        public async Task<MenuItem> UpdateMenuItem(int id, MenuItem menuItem)
        {
            // get menu item to be updated by id
            var menuItemDomain = await dbContext.menuItems.FirstOrDefaultAsync(x => x.Id == id);

            menuItemDomain.Name = menuItem.Name;
            menuItemDomain.Description = menuItem.Description;
            menuItemDomain.Price = menuItem.Price;
            menuItemDomain.Category = menuItem.Category;
            menuItemDomain.SpecialTag = menuItem.SpecialTag;
            menuItemDomain.Image = menuItem.Image;

            await dbContext.SaveChangesAsync();

            return menuItemDomain;
        }
    }
}
