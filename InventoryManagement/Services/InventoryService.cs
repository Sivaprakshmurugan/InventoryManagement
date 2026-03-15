using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryItem>> GetAllItems()
        {
            return await _context.InventoryItems.Where(x => x.Status != 99).ToListAsync();
        }

        public async Task<InventoryItem> GetItem(int id)
        {
            
           var result = await _context.InventoryItems.FirstOrDefaultAsync(x => x.Id == id);
           
            return result;
        }

        public async Task AddItem(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(InventoryItem item)
        {
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item != null)
            {
                item.Status = 99;//Status 99 is deleted items
                _context.InventoryItems.Update(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
