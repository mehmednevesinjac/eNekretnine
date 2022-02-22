using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.Model
{
    public class Grad
    {
        [Key]
        public int GradId { get; set; }
        public string Naziv { get; set; }

        [ForeignKey(nameof(Drzave))]
        public int DrzavaId { get; set; }
        public Drzave Drzave { get; set; }
    }
}
