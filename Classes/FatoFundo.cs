using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos.Classes
{
    class FatoFundo
    {
        public List<Aplicacao> ListaAplicacao { get; set; }
        
        public string Retirar(float ValorRetirar)
        {
            foreach(Aplicacao app in ListaAplicacao)
            {
                if (ValorRetirar == app.ValorAplicado)
                {
                    ListaAplicacao.Remove(app);
                    string Sucesso = "Sucesso! Valor Retirado.";
                    return Sucesso;
                }
            }
            string Falha = "Erro! Valor Invalido";
            return Falha;
        }
    }
}
