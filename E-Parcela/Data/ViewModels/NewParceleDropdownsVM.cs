using E_Parcela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
namespace E_Parcela.Data.ViewModels
{
    public class NewParceleDropdownsVM
    {
        public NewParceleDropdownsVM()
        {
            Zaposlenici = new List<Zaposlenici>();
            Suradnici = new List<Suradnici>();
            Sadnice = new List<Sadnice>();
        }

        public List<Zaposlenici> Zaposlenici { get; set; }
        public List<Suradnici> Suradnici { get; set; }
        public List<Sadnice> Sadnice { get; set; }
    }
}

