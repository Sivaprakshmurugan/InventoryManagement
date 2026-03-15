using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IInventoryService
    {
        Task<List<InventoryItem>> GetAllItems();

        Task<InventoryItem> GetItem(int id);

        Task AddItem(InventoryItem item);

        Task UpdateItem(InventoryItem item);

        Task DeleteItem(int id);
    }
}
