using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaiFundos.Classes;
using VaiFundos.Views;

namespace VaiFundos
{
    class Program
    {
        public static List<ContratoContabil> contratosAtuais = new List<ContratoContabil>();

        static void Main(string[] args)
        {
            UtilLayout utlay = new UtilLayout();
            string resp = "";
            int resadeira = 0;
            while (resadeira == 0)
            {
                Console.Clear();
                Console.WriteLine("   Menu SAP - Vai Fundo!\n 1 - Cadastrar Contrato\n 2 - Relatório A\n 3 - Relatório B\n 4 - Retirada\n 5 - Transferir Aplicação\n 6 - Sair");
                Console.Write("Opção: ");
                resp = Console.ReadLine();
                switch (resp)
                {
                    case "1":
                        contratosAtuais = utlay.CriarContratoContabil(contratosAtuais);
                        break;
                    case "2":
                        contratosAtuais = utlay.RelatorioA(contratosAtuais);
                        break;
                    case "3":
                        contratosAtuais = utlay.RelatorioB(contratosAtuais);
                        break;
                    case "4":
                        contratosAtuais = utlay.Retirada(contratosAtuais);
                        break;
                    case "5":
                        contratosAtuais = utlay.Transferencia(contratosAtuais);
                        break;
                    case "6":
                        resadeira = 1;
                        break;
                }
            }
        }
    }
}

