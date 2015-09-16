using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos.Classes
{
    class ContratoContabil
    {
        public List<Aplicacao> listaAplicacao { get; set; }
        public DateTime dataInicial { get; set; }
        public Fundo fundo { get; set; }
        public Cliente cliente { get; set; }

        public ContratoContabil(DateTime pDataInicial, Fundo pFundo, Cliente pCliente, List<Aplicacao> pListaAplicacao)
        {
            if (pListaAplicacao.Count > 0)
            {
                this.dataInicial = pDataInicial;
                this.listaAplicacao = pListaAplicacao;
                this.fundo = pFundo;
                this.cliente = pCliente;
            }
        }

        public string Retirar(double ValorRetirar)
        {
            foreach (Aplicacao app in listaAplicacao)
            {
                if (ValorRetirar == app.valorAplicado)
                {
                    int rem = CalculoPercentualRemuneração();
                    double MontanteRetirado = app.valorAplicado + (app.valorAplicado * (rem/100))- (app.valorAplicado * (fundo.MoedaPadrao.Tributo));
                    MontanteRetirado = Math.Round(MontanteRetirado);
                    Util utl = new Util();
                    listaAplicacao.Remove(app);
                    utl.CalculoCedulas(MontanteRetirado);
                    string Sucesso = "\n Sucesso! Valor Retirado: " + MontanteRetirado + ".";
                    return Sucesso;
                }
            }
            string Falha = "Erro! Valor Inválido";
            return Falha;
        }

        private int CalculoPercentualRemuneração()
        {
            int dias = (DateTime.Now - this.dataInicial).Days;
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
