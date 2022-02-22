using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.Model
{
    public class Lokacije
    {
        [Key]
        public int LokacijaID { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
