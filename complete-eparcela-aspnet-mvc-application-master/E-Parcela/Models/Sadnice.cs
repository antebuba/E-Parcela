using E_Parcela.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Parcela.Models
{
    public class Sadnice:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Slika sadnice")]
        [Required(ErrorMessage ="Potreban link slike")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Ime")]

        public string FUllName { get; set; }


        [Display(Name = "Biografija")]
        [Required(ErrorMessage = "Potrebna biografija")]

        public string Bio { get; set; }
        [Display(Name ="Cijena po komadu")]
        [Required(ErrorMessage = "Potrebna cijena po komadu")]

        public double Price { get; set; }

        //Relationships
        public List<Sadnice_Parcele> Sadnice_Parcele { get; set; }
    }
}
