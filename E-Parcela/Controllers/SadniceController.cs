using E_Parcela.Data;
using E_Parcela.Data.Services;
using E_Parcela.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace E_Parcela.Controllers
{
    public class SadniceController : Controller
    {
        private readonly ISadniceService _service;

        public SadniceController(ISadniceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FUllName,ProfilePictureURL,Bio,Price")] Sadnice sadnice)
        {
            if (!ModelState.IsValid)
            {
                return View(sadnice);
            }
            await _service.AddAsync(sadnice);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var sadniceDetails = await _service.GetByIdAsync(id);

            if (sadniceDetails == null) return View("NotFound");
            return View(sadniceDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var sadniceDetails = await _service.GetByIdAsync(id);
            if (sadniceDetails == null) return View("NotFound");
            return View(sadniceDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FUllName,ProfilePictureURL,Bio,Price")] Sadnice sadnice)
        {
            if (!ModelState.IsValid)
            {
                return View(sadnice);
            }
            await _service.UpdateAsync(id, sadnice);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var sadniceDetails = await _service.GetByIdAsync(id);
            if (sadniceDetails == null) return View("NotFound");
            return View(sadniceDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sadniceDetails = await _service.GetByIdAsync(id);
            if (sadniceDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}