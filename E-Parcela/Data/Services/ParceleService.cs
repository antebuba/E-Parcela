using E_Parcela.Data.Base;
using E_Parcela.Data.ViewModels;
using E_Parcela.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Parcela.Data.Services
{
    public class ParceleService : EntityBaseRepository<Parcele>, IParceleService
    {
        private readonly AppDbContext _context;

        public ParceleService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewParceleAsync(NewParceleVM data)
        {
            var newParcele = new Parcele()
            {
                Name = data.Name,
                Description = data.Description,
                ImageURL = data.ImageURL,
                SuradniciID = data.SuradniciID,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ParcelaCategory = data.ParcelaCategory,
                ZaposleniciID = data.ZaposleniciID
            };
            await _context.Parcele.AddAsync(newParcele);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var sadnicaID in data.SadniceIDs)
            {
                var newSadniceParcele = new Sadnice_Parcele()
                {
                    ParceleID = newParcele.Id,
                    SadniceID = sadnicaID
                };
                await _context.Sadnice_Parcele.AddAsync(newSadniceParcele);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<NewParceleDropdownsVM> GetNewParceleDropdownsValues()
        {
            var response = new NewParceleDropdownsVM()
            {
                Sadnice = await _context.Sadnice.OrderBy(n => n.FUllName).ToListAsync(),
                Suradnici = await _context.Suradnici.OrderBy(n => n.Name).ToListAsync(),
                Zaposlenici = await _context.Zaposlenici.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task<Parcele> GetParceleByIdAsync(int id)
        {
            var parceleDetails = await _context.Parcele
                .Include(c => c.Suradnici)
                .Include(p => p.Zaposlenici)
                .Include(am => am.Sadnice_Parcele).ThenInclude(a => a.Sadnice)
                .FirstOrDefaultAsync(n => n.Id == id);

            return parceleDetails;
        }
        public async Task UpdateParceleAsync(NewParceleVM data)
        {
            var dbMovie = await _context.Parcele.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.SuradniciID = data.SuradniciID;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.ParcelaCategory = data.ParcelaCategory;
                dbMovie.ZaposleniciID = data.ZaposleniciID;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Sadnice_Parcele.Where(n => n.ParceleID == data.Id).ToList();
            _context.Sadnice_Parcele.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.SadniceIDs)
            {
                var newActorMovie = new Sadnice_Parcele()
                {
                    ParceleID = data.Id,
                    SadniceID = actorId
                };
                await _context.Sadnice_Parcele.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

       
    }
}
