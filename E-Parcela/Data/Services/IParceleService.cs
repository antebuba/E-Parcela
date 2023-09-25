using E_Parcela.Data.Base;
using E_Parcela.Models;
using E_Parcela.Data.ViewModels;


namespace E_Parcela.Data.Services
{
    public interface IParceleService:IEntityBaseRepository<Parcele>
    {
        Task<Parcele> GetParceleByIdAsync(int id);
        Task<NewParceleDropdownsVM> GetNewParceleDropdownsValues();
        Task AddNewParceleAsync(NewParceleVM data);
        Task UpdateParceleAsync(NewParceleVM data);





    }
}
