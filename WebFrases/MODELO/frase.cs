using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class frase
    {
        public int id { get; set; }

        public String texto { get; set; }

        public int autor { get; set; }

        public int categoria { get; set; }

    }
}