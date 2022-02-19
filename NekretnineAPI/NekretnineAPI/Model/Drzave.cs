using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.Model
{
    public class Drzave
    {
        [Key]
        public int DrzavaID { get; set; }
        public string Naziv { get; set; }
    }
}
