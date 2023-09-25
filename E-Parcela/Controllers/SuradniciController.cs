using E_Parcela.Data;
using E_Parcela.Data.Services;
using E_Parcela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Parcela.Controllers
{
    public class SuradniciController : Controller
    {
        private readonly ISuradniciService _service;

        public SuradniciController(ISuradniciService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSuradnici = await _service.GetAllAsync();
            return View(allSuradnici);
        }


        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Ime,Description")] Suradnici suradnici)
        {
            if (!ModelState.IsValid) return View(suradnici);
            await _service.AddAsync(suradnici);
            return RedirectToAction(nameof(Index));
        }


        //Get: Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var suradniciDetails = await _service.GetByIdAsync(id);
            if (suradniciDetails == null) return View("NotFound");
            return View(suradniciDetails);
        }
        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var suradniciDetails = await _service.GetByIdAsync(id);
            if (suradniciDetails == null) return View("NotFound");
            return View(suradniciDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Suradnici suradnici)
        {
            if (!ModelState.IsValid) return View(suradnici);
            await _service.UpdateAsync(id, suradnici);
            return RedirectToAction(nameof(Index));
        }
        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var suradniciDetails = await _service.GetByIdAsync(id);
            if (suradniciDetails == null) return View("NotFound");
            return View(suradniciDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var suradniciDetails = await _service.GetByIdAsync(id);
            if (suradniciDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
