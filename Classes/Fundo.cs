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
        public DateTime DataInicial { get; set; }

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

        public double Valor()
        {

            return 0d;
        }

        private int CalculoPercentualRemuneração()
        {
            int dias = (DateTime.Now - this.DataInicial).Days;
            if (dias > 0)
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (dias < 365 * (i + 1))
                        return 5 * i;
                }
            }
            return 0;
        }
    }
}
