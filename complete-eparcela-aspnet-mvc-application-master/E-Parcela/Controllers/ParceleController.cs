using E_Parcela.Data;
using E_Parcela.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Parcela.Models;

namespace E_Parcela.Controllers
{
    public class ParceleController : Controller
    {
        private readonly IParceleService _service;

        public ParceleController(IParceleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allParcele = await _service.GetAllAsync(n => n.Suradnici);
            return View(allParcele);
        }

        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetParceleByIdAsync(id);
            return View(movieDetail);
        }
        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var parceleDropdownsData = await _service.GetNewParceleDropdownsValues();

            ViewBag.Suradnici = new SelectList(parceleDropdownsData.Suradnici, "Id", "Name");
            ViewBag.Zaposlenici = new SelectList(parceleDropdownsData.Zaposlenici, "Id", "FullName");
            ViewBag.Sadnice = new SelectList(parceleDropdownsData.Sadnice, "Id", "FUllName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewParceleVM parcele)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewParceleDropdownsValues();

                ViewBag.Suradnici = new SelectList(movieDropdownsData.Suradnici, "Id", "Name");
                ViewBag.Zaposlenici = new SelectList(movieDropdownsData.Zaposlenici, "Id", "FullName");
                ViewBag.Sadnice = new SelectList(movieDropdownsData.Sadnice, "Id", "FUllName");

                return View(parcele);
            }

            await _service.AddNewParceleAsync(parcele);
            return RedirectToAction(nameof(Index));
        }
        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var parceleDetails = await _service.GetParceleByIdAsync(id);
            if (parceleDetails == null) return View("NotFound");

            var response = new NewParceleVM()
            {
                Id = parceleDetails.Id,
                Name = parceleDetails.Name,
                Description = parceleDetails.Description,
                StartDate = parceleDetails.StartDate,
                EndDate = parceleDetails.EndDate,
                ImageURL = parceleDetails.ImageURL,
                ParcelaCategory = parceleDetails.ParcelaCategory,
                SuradniciID = parceleDetails.SuradniciID,
                ZaposleniciID = parceleDetails.ZaposleniciID,
                SadniceIDs = parceleDetails.Sadnice_Parcele.Select(n => n.SadniceID).ToList(),
            };

            var movieDropdownsData = await _service.GetNewParceleDropdownsValues();
            ViewBag.Suradnici = new SelectList(movieDropdownsData.Suradnici, "Id", "Name");
            ViewBag.Zaposlenici = new SelectList(movieDropdownsData.Zaposlenici, "Id", "FullName");
            ViewBag.Sadnice = new SelectList(movieDropdownsData.Sadnice, "Id", "FUllName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewParceleVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewParceleDropdownsValues();

                ViewBag.Suradnici = new SelectList(movieDropdownsData.Suradnici, "Id", "Name");
                ViewBag.Zaposlenici = new SelectList(movieDropdownsData.Zaposlenici, "Id", "FullName");
                ViewBag.Sadnice = new SelectList(movieDropdownsData.Sadnice, "Id", "FUllName");

                return View(movie);
            }

            await _service.UpdateParceleAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
