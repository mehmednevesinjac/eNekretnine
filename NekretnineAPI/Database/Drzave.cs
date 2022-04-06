using System;
using System.Collections.Generic;

namespace Database
{
    public partial class Drzave
    {
        public Drzave()
        {
            Grads = new HashSet<Grad>();
        }

        public int DrzavaId { get; set; }
        public string? Naziv { get; set; }

        public virtual ICollection<Grad> Grads { get; set; }
    }
}
