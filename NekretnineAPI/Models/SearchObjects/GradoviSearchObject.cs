﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchObjects
{
    public class GradoviSearchObject : BaseSearchObject
    {
        public string? Naziv { get; set; }
        public int? DrzavaId { get; set; }
    }
}
