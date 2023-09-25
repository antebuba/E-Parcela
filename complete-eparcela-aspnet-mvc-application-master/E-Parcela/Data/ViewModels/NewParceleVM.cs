using E_Parcela.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Parcela.Models
{
    public class NewParceleVM
    {
        public int Id { get; set; }

        [Display(Name = "Ime Parcele")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Opis parcele")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

       

        [Display(Name = "Slika URL")]
        [Required(ErrorMessage = " URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Pocetak ugovora")]
        [Required(ErrorMessage = "Start date is required")]
        public string StartDate { get; set; }

        [Display(Name = "Kraj ugovora")]
        [Required(ErrorMessage = "End date is required")]
        public string EndDate { get; set; }

        [Display(Name = "Odaberi kategoriju")]
        [Required(ErrorMessage = "Category is required")]
        public ParcelaCategory ParcelaCategory { get; set; }

        //Relationships
        [Display(Name = "Izaberi sadnice")]
        [Required(ErrorMessage = "Select is required")]
        public List<int> SadniceIDs { get; set; }

        [Display(Name = "Izaberi Suradnika")]
        [Required(ErrorMessage = "select is required")]
        public int SuradniciID { get; set; }

        [Display(Name = "Izaberi zaposlenika")]
        [Required(ErrorMessage = "Select is required")]
        public int ZaposleniciID { get; set; }
    }
}
