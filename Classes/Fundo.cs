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
        public List<FatoFundo> FatoReferencia { get; set; }

        public Fundo(Moeda pMoedaPadrao, List<FatoFundo> pFatoReferencia)
        {
            foreach (FatoFundo fato in pFatoReferencia)
            {
                if (fato.ListaAplicacao.Count == 0)
                    break;
            }
            this.MoedaPadrao = pMoedaPadrao;
            this.FatoReferencia = pFatoReferencia;

        }
    }
}
