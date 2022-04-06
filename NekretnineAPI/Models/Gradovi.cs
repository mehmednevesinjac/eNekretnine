using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Gradovi
    {
        public int GradId { get; set; }
        public string? Naziv { get; set; }
        public Drzave? Drzava { get; set; }
    }
}
