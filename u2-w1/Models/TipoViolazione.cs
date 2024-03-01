using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u2_w1.Models
{
    public class TipoViolazione
    {
        public int IdViolazione { get; set; }
        public string Descrizione { get; set; }
        public bool Contestabile { get; set; }
    }
}