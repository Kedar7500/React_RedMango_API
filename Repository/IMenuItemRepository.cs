using RedMango_API.Models.Domain;

namespace RedMango_API.Repository
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetMenuItems();

        Task<MenuItem> GetMenuItem(int id);

        Task<MenuItem> CreateMenuItem(MenuItem menuItem);

        Task<MenuItem> UpdateMenuItem(int id, MenuItem menuItem);

        Task<MenuItem> DeleteMenuItem(int id);
    }
}
