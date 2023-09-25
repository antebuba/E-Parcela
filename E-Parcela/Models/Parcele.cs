using E_Parcela.Data.Base;
using E_Parcela.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace E_Parcela.Models
{
    public class Parcele:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ParcelaCategory ParcelaCategory { get; set; }

        
        //Relationship

        public List<Sadnice_Parcele> Sadnice_Parcele { get; set; }

        //Suradnici

        public int SuradniciID { get; set; }
        [ForeignKey("SuradniciID")]
        public Suradnici Suradnici { get; set; }

        //Zaposlenici

        public int ZaposleniciID { get; set; }
        [ForeignKey("ZaposleniciID")]
        public Zaposlenici Zaposlenici { get; set; }



    }
}
