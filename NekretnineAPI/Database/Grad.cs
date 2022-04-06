using System;
using System.Collections.Generic;

namespace Database
{
    public partial class Grad
    {
        public Grad()
        {
            Lokacijes = new HashSet<Lokacije>();
        }

        public int GradId { get; set; }
        public string? Naziv { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzave Drzava { get; set; } = null!;
        public virtual ICollection<Lokacije> Lokacijes { get; set; }
    }
}
