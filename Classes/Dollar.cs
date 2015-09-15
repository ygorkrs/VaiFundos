using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos.Classes
{
    class Dollar : Moeda
    {        
        public Dollar()
        {
            this.Nome = "Dollar";
            this.Sigla = "$";
            this.Tributo = 0.01f;
        }
    }
}
