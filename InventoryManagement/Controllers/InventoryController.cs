using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Filters;

namespace InventoryManagement.Controllers
{
    [SessionAuthorize]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _service.GetAllItems();
            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryItem item)
        {
            await _service.AddItem(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.GetItem(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InventoryItem item)
        {
            await _service.UpdateItem(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
