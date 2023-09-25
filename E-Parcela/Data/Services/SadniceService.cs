using E_Parcela.Data.Base;
using E_Parcela.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace E_Parcela.Data.Services
{
    public class SadniceService : EntityBaseRepository<Sadnice>, ISadniceService
    {
        public SadniceService(AppDbContext context) : base(context) { }
        
        
    }
}
