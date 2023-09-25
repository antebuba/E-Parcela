namespace E_Parcela.Models
{
    public class Sadnice_Parcele
    {
        public int ParceleID { get; set; }
        public Parcele Parcele { get; set; }

        public int SadniceID { get; set; }
        public Sadnice Sadnice { get; set; }

    }
}
