using E_Parcela.Data.Base;
using System.ComponentModel.DataAnnotations;
using System;

namespace E_Parcela.Models
{
    public class Suradnici:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name= "Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]

        public string Logo { get; set; }
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Cinema name is required")]


        public string Name { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Cinema description is required")]


        public string Description { get; set; }

        //Relationship

        public List<Parcele> Parcele { get; set; }
    }
}
