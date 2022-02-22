using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.ViewModel
{
    public class LokacijeVM
    {
        public int LokacijaId { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public int GradId { get; set; }
    }
}
