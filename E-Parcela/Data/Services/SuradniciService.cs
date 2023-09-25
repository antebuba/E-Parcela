using E_Parcela.Data.Base;
using E_Parcela.Models;

namespace E_Parcela.Data.Services
{
    public class SuradniciService : EntityBaseRepository<Suradnici>, ISuradniciService
    {
        public SuradniciService(AppDbContext context) : base(context)
        {
        }
    }
}
