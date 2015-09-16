using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos.Classes
{
    class Real : Moeda
    {
        public Real()
        {
            this.Nome = "Real";
            this.Sigla = "R$";
            this.Tributo = 0.2f;
        }
    }
}
