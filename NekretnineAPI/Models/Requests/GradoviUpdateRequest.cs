using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class GradoviUpdateRequest
    {
        public string? Naziv { get; set; }
        public int DrzavaId { get; set; }
    }
}
