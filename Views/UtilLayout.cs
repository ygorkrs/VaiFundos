using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaiFundos.Classes;

namespace VaiFundos.Views
{
    class UtilLayout
    {
        public List<ContratoContabil> CriarContratoContabil(List<ContratoContabil> pContratosAtuais)
        {
            List<ContratoContabil> aux = new List<ContratoContabil>();
            aux = pContratosAtuais;
            #region Cliente

            Cliente clienteTitular = new Cliente();
            Console.Clear();
            Console.WriteLine("Deseja Cadastrar um cliente? (1 - Sim; 2 - Não, cliente já cadastrado)");
            Console.Write("Opção: ");
            string resp = Console.ReadLine();
            switch (resp)
            {
                case "1":
                    Cliente novoCliente = new Cliente();
                    Console.Clear();
                    Console.WriteLine("     - Cadastro de Clientes -");
                    Console.WriteLine(" Informe os campos abaixo: ");
                    Console.Write(" Conta: ");
                    novoCliente.numeroConta = Console.ReadLine();
                    Console.Write(" Nome: ");
                    novoCliente.nome = Console.ReadLine();
                    clienteTitular = novoCliente;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("     - Localizador de Clientes -");
                    Console.WriteLine(" Informe a conta do cliente desejado: ");
                    Console.Write(" Conta: ");
                    string pcont = Console.ReadLine();
                    foreach (ContratoContabil ct in pContratosAtuais)
                    {
                        if (ct.cliente.numeroConta == pcont)
                        {
                            clienteTitular = ct.cliente;
                            break;
                        }

                    }
                    if (clienteTitular.nome == null || clienteTitular.numeroConta == null)
                    {
                        Console.WriteLine("\n\n[Conta não encontrada]\n\n\n");
                        Console.WriteLine("     - Cadastro de Clientes -");
                        Console.WriteLine(" Informe os campos abaixo: ");
                        Console.Write(" Conta: ");
                        clienteTitular.numeroConta = Console.ReadLine();
                        Console.Write(" Nome: ");
                        clienteTitular.nome = Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Entrada inesperada!");
                    break;
            }

            #endregion

            #region Fundo

            Fundo fundo = new Fundo(new Dollar());
            Console.Clear();
            Console.WriteLine("Deseja Cadastrar um fundo? (1 - Sim; 2 - Não, fundo já cadastrado)");
            Console.Write("Opção: ");
            resp = Console.ReadLine();
            switch (resp)
            {
                case "1":
                    resp = "ZeroGodsReset";
                    Moeda moeda = null;
                    while (resp != "D" && resp != "R")
                    {
                        Console.Clear();
                        Console.WriteLine("     - Cadastro de Fundos -");
                        Console.WriteLine(" Informe os campos abaixo: ");
                        Console.WriteLine(" Moeda: (D - Dollar; R - Real)");
                        Console.Write("Opção: ");
                        resp = Console.ReadLine();

                        if (resp == "D")
                            moeda = new Dollar();
                        else
                        {
                            if (resp == "R")
                                moeda = new Real();
                        }
                    }
                    Fundo novoFundo = new Fundo(moeda);
                    Console.Write(" ID: ");
                    novoFundo.id = Console.ReadLine();
                    fundo = novoFundo;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("     - Localizador de Fundos -");
                    Console.WriteLine(" Informe a id do Fundo desejado: ");
                    Console.Write(" ID do Fundo: ");
                    string pId = Console.ReadLine();
                    foreach (ContratoContabil ct in pContratosAtuais)
                    {
                        if (ct.fundo.id == pId)
                        {
                            fundo = ct.fundo;
                            break;
                        }

                    }
                    if (fundo.MoedaPadrao.Nome == null || fundo.id == null)
                    {
                        Console.WriteLine("\n\n[Fundo não encontrado]\n\n\n");
                        moeda = null;
                        while (resp != "D" && resp != "R")
                        {
                            Console.WriteLine("     - Cadastro de Fundos -");
                            Console.WriteLine(" Informe os campos abaixo: ");
                            Console.WriteLine(" Moeda: (D - Dollar; R - Real)");
                            Console.Write("Opção: ");
                            resp = Console.ReadLine();

                            if (resp == "D")
                                moeda = new Dollar();
                            else
                            {
                                if (resp == "R")
                                    moeda = new Real();
                            }
                        }
                        novoFundo = new Fundo(moeda);
                        Console.Write(" ID: ");
                        novoFundo.id = Console.ReadLine();
                        fundo = novoFundo;
                    }
                    break;
                default:
                    Console.WriteLine("Entrada inesperada!");
                    break;
            }

            #endregion

            #region Aplicações
            List<Aplicacao> liAp = new List<Aplicacao>();
            Console.Clear();
            double valorApl = 0;
            while (valorApl == 0)
            {
                Console.Clear();
                Console.WriteLine("     - Cadastro de Aplicações -\n\n");
                Console.WriteLine(" * Para sua maior segurança se faz necessária a primeira aplicação para validar o contrato");
                Console.Write("\nFavor inserir o valor da primeira aplicação: ");
                try
                {
                    valorApl = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    valorApl = 0;
                }
            }
            Aplicacao novaAplic = new Aplicacao();
            novaAplic.valorAplicado = valorApl;
            novaAplic.dataAplicacao = DateTime.Now;
            liAp.Add(novaAplic);

            Console.WriteLine("\n\n Aplicação cadastrada! \n");
            resp = "ResetGodsLevel";
            Console.WriteLine("Deseja Cadastrar outra Aplicação? (S - Sim ou N - Não)");
            Console.Write("Opção: ");
            resp = Console.ReadLine();
            while (resp == "S" || resp == "s")
            {
                valorApl = 0;
                while (valorApl == 0)
                {
                    Console.Clear();
                    Console.Write("Favor inserir o valor da aplicação: ");
                    valorApl = Convert.ToDouble(Console.ReadLine());
                }
                Aplicacao aplc = new Aplicacao();
                aplc.valorAplicado = valorApl;
                aplc.dataAplicacao = DateTime.Now;
                liAp.Add(aplc);
                Console.WriteLine("\n\n Aplicação cadastrada! \n");
                Console.WriteLine("Deseja Cadastrar outra Aplicação? (S - Sim ou N - Não)");
                Console.Write("Opção: ");
                resp = Console.ReadLine();
            }

            #endregion

            #region Contrato
            ContratoContabil novoContrato = new ContratoContabil(DateTime.Now, fundo, clienteTitular, liAp);
            aux.Add(novoContrato);
            #endregion

            return aux;
        }

        public List<ContratoContabil> Retirada(List<ContratoContabil> pContratosAtuais)
        {
            List<ContratoContabil> aux = new List<ContratoContabil>();
            aux = pContratosAtuais;

            double valorApl = 0;
            string resp = "";
            ContratoContabil ctb = null;
            Console.Clear();
            Console.WriteLine("     - Modulo de Retiradas -\n\n");
            Console.WriteLine(" Favor informar o ID do Fundo do qual se deseja se realizar a retirada: ");
            Console.Write("ID: ");
            resp = Console.ReadLine();
            Console.Write("\nFavor inserir o valor que se deseja retirar: ");
            try
            {
                valorApl = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                valorApl = 0;
            }
            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if (ct.fundo.id == resp)
                {
                    ctb = ct;
                    break;
                }

            }
            Console.WriteLine(ctb.Retirar(valorApl));
            Console.ReadKey();
            return aux;
        }

        public List<ContratoContabil> Transferencia(List<ContratoContabil> pContratosAtuais)
        {
            List<ContratoContabil> aux = new List<ContratoContabil>();
            aux = pContratosAtuais;
            Fundo fundoOri = new Fundo(new Moeda());
            Fundo fundoDes = new Fundo(new Moeda());
            Cliente clienteTitular = new Cliente();
            ContratoContabil c1 = null;
            ContratoContabil c2 = null;


            Console.Clear();
            Console.WriteLine("     - Localizador de Clientes -");
            Console.WriteLine(" Informe a conta do cliente desejado: ");
            Console.Write(" Conta: ");
            string pcont = Console.ReadLine();
            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if (ct.cliente.numeroConta == pcont)
                {
                    clienteTitular = ct.cliente;
                    break;
                }

            }

            Console.WriteLine(" Informe a id do Fundo de Origem: ");
            Console.Write(" ID do Fundo: ");
            string pId = Console.ReadLine();
            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if (ct.fundo.id == pId)
                {
                    fundoOri = ct.fundo;
                    break;
                }

            }

            Console.WriteLine(" Informe a id do Fundo Destino: ");
            Console.Write(" ID do Fundo: ");
            pId = Console.ReadLine();
            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if (ct.fundo.id == pId)
                {
                    fundoDes = ct.fundo;
                    break;
                }

            }

            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if(ct.cliente.numeroConta == clienteTitular.numeroConta)
                {
                    if (ct.fundo.id == fundoOri.id)
                        c1 = ct;
                    if (ct.fundo.id == fundoDes.id)
                        c2 = ct;

                }
            }
            aux.Remove(c1);
            aux.Remove(c2);
            if (c1.fundo.MoedaPadrao.Sigla == c2.fundo.MoedaPadrao.Sigla)
            {
                foreach(Aplicacao ap in c1.listaAplicacao)
                {
                    if (c1.fundo.MoedaPadrao.Sigla == "R$")
                    {
                        Aplicacao aps = new Aplicacao();
                        aps.dataAplicacao = ap.dataAplicacao;
                        aps.valorAplicado = ap.valorAplicado - 10;
                        c2.listaAplicacao.Add(aps);
                    }
                    else
                    {
                        c2.listaAplicacao.Add(ap);
                    }
                }
            }
            aux.Add(c2);
            return aux;
        }

        public List<ContratoContabil> RelatorioA(List<ContratoContabil> pContratosAtuais)
        {
            List<ContratoContabil> aux = new List<ContratoContabil>();
            aux = pContratosAtuais;
            Cliente clienteTitular = new Cliente();
            Console.Clear();
            Console.WriteLine("     - Localizador de Clientes -");
            Console.WriteLine(" Informe a conta do cliente desejado: ");
            Console.Write(" Conta: ");
            string pcont = Console.ReadLine();
            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if (ct.cliente.numeroConta == pcont)
                {
                    Console.Clear();
                    Console.WriteLine("Relatorio A\n\n");
                    foreach(Aplicacao apl in ct.listaAplicacao)
                    {
                        Console.WriteLine("Data Aplicação: {0}, Valor {1}", apl.dataAplicacao.ToString(),apl.valorAplicado);
                    }
                    break;
                }

            }

            return aux;
        }

        public List<ContratoContabil> RelatorioB(List<ContratoContabil> pContratosAtuais)
        {
            List<ContratoContabil> aux = new List<ContratoContabil>();
            aux = pContratosAtuais;

            Console.WriteLine(" Informe o mês desejado: ");
            Console.Write(" Mês: ");
            string pcont = Console.ReadLine();
            foreach (ContratoContabil ct in pContratosAtuais)
            {
                if (pcont == ct.dataInicial.Month.ToString())
                {
                    foreach (Aplicacao apl in ct.listaAplicacao)
                    {
                        Console.WriteLine("Data Aplicação: {0}, Valor {1}, ID Fundo: {2}", 
                            apl.dataAplicacao.ToString(), apl.valorAplicado, ct.fundo.id);
                    }
                }
                break;
            }

                return aux;
        }
    }
}
