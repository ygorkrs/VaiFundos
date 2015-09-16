using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos.Classes
{
    class Fundo
    {
        public Moeda MoedaPadrao { get; set; }
        public string id { get; set; }

        public Fundo(Moeda pMoedaPadrao)
        {
            this.MoedaPadrao = pMoedaPadrao;
        }
    }
}
