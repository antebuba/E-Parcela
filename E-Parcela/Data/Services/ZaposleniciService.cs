using E_Parcela.Data.Base;
using E_Parcela.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace E_Parcela.Data.Services
{
    public class ZaposleniciService : EntityBaseRepository<Zaposlenici>, IZaposleniciService
    {
        public ZaposleniciService(AppDbContext context) : base(context) { }


    }
}

