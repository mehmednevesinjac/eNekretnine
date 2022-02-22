using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.Model
{
    public class TipNekretnine
    {
        [Key]
        public int TipNekretnineID { get; set; }
        public string NazivTipa { get; set; }

      
    }
}
