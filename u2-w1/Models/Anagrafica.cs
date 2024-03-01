using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace u2_w1.Models
{
    public class Anagrafica
    {

        public int IdAnagrafica { get; set; }
        [DisplayName("Cognome")]
        public string Cognome { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Indirizzo")]
        public string Indirizzo { get; set; }
        [DisplayName("Città")]
        public string Citta { get; set; }
        [DisplayName("CAP")]
        public string CAP { get; set; }
        [DisplayName("Codice Fiscale.")]
        public string CF { get; set; }
    }
}