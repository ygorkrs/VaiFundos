using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaiFundos.Classes;

namespace VaiFundos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aplicacao app = new Aplicacao();
            //FatoFundo fato = new FatoFundo();
            //List<Aplicacao> ltapp = new List<Aplicacao>();
            //ltapp.Add(app);
            //fato.ListaAplicacao = ltapp;
            //List<FatoFundo> ltfundo = new List<FatoFundo>();
            //ltfundo.Add(fato);
            //Dollar dollares = new Dollar();
            //try {
            //    Fundo fundo = new Fundo(dollares, ltfundo);
            //}catch (Exception e)
            //{
            //    e = new Exception("Sem Aplicação referente ao fundo");
            //    Console.WriteLine(e.Message);
            //}
            //Console.ReadKey();

            Util utl = new Util();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Valor = ");
                utl.CalculoCedulas(double.Parse(Console.ReadLine()));
                //Console.ReadKey();
            }
        }
    }
}
