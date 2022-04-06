using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lokacije
    {
        public int LokacijaId { get; set; }
        public string? Ulica { get; set; }
        public int Broj { get; set; }
        public Gradovi? Grad { get; set; }
    }
}
