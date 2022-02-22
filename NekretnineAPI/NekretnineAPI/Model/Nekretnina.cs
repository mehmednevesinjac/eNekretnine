using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.Model
{
    public class Nekretnina
    {
        [Key]
        public int NekretninaId { get; set; }

        [ForeignKey(nameof(TipNekretnine))]
        public int TipNekretnineId { get; set; }
        public TipNekretnine TipNekretnine { get; set; }

        [ForeignKey(nameof(Lokacija))]
        public int LokacijaId { get; set; }
        public Lokacije Lokacija { get; set; }

        public float Cijena { get; set; }
        public bool Izdato { get; set; }
        public int BrojSpratova { get; set; }
        public int BrojSoba { get; set; }
        public float Velicina { get; set; }
        public float CijenaDIjela { get; set; }
        public string Opis { get; set; }
    }
}
