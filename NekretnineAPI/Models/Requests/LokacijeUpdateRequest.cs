using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class LokacijeUpdateRequest
    {
        public string? Ulica { get; set; }
        public int Broj { get; set; }
        public int GradId { get; set; }
    }
}
