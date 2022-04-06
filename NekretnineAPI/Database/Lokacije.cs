using System;
using System.Collections.Generic;

namespace Database
{
    public partial class Lokacije
    {
        public int LokacijaId { get; set; }
        public string? Ulica { get; set; }
        public int Broj { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; } = null!;
    }
}
