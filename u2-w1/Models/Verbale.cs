using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u2_w1.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataViolazione { get; set; }

        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }

        public int IdAnagrafica { get; set; }

        public int IdViolazione { get; set; }
    }
}