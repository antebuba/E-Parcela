using E_Parcela.Data;
using E_Parcela.Data.Services;
using E_Parcela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Parcele.Controllers
{
    public class ZaposleniciController : Controller
    {
        private readonly IZaposleniciService _service;

        public ZaposleniciController(IZaposleniciService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allZaposlenici = await _service.GetAllAsync();
            return View(allZaposlenici);
        }

        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var zaposleniciDetails = await _service.GetByIdAsync(id);
            if (zaposleniciDetails == null) return View("NotFound");
            return View(zaposleniciDetails);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Zaposlenici zaposlenici)
        {
            if (!ModelState.IsValid) return View(zaposlenici);

            await _service.AddAsync(zaposlenici);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var zaposleniciDetails = await _service.GetByIdAsync(id);
            if (zaposleniciDetails == null) return View("NotFound");
            return View(zaposleniciDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Zaposlenici zaposlenici)
        {
            if (!ModelState.IsValid) return View(zaposlenici);

            if (id == zaposlenici.Id)
            {
                await _service.UpdateAsync(id, zaposlenici);
                return RedirectToAction(nameof(Index));
            }
            return View(zaposlenici);
        }
        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var zaposleniciDetails = await _service.GetByIdAsync(id);
            if (zaposleniciDetails == null) return View("NotFound");
            return View(zaposleniciDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaposleniciDetails = await _service.GetByIdAsync(id);
            if (zaposleniciDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
