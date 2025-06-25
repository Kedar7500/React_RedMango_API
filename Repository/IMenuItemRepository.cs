using RedMango_API.Models.Domain;

namespace RedMango_API.Repository
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetMenuItems();
    }
}
