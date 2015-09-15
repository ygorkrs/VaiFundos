using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaiFundos.Classes
{
    class Util
    {
        public void CalculoCedulas(double valor)
        {
            int qtda50 = 0;
            int qtda20 = 0;
            int qtda10 = 0;
            int qtda5 = 0;
            int qtda2 = 0;
            while (valor >= 2)
            {
                if (valor >= 50)
                {
                    valor -= 50;
                    qtda50++;
                }
                else
                {
                    if (valor >= 20)
                    {
                        valor -= 20;
                        qtda20++;
                    }
                    else
                    {
                        if (valor >= 10)
                        {
                            valor -= 10;
                            qtda10++;
                        }
                        else
                        {
                            if (valor >= 5)
                            {
                                valor -= 5;
                                qtda5++;
                            }
                            else
                            {
                                if (valor >= 2)
                                {
                                    valor -= 2;
                                    qtda2++;
                                }
                            }
                        }
                    }
                }
            }
            if (valor > 0)
            {
                qtda2++;
            }
            Console.WriteLine("");
            Console.WriteLine("  ####################################################");
            Console.WriteLine("  #   Quantidade de cédulas de 50: {0}                 #", qtda50);
            Console.WriteLine("  #   Quantidade de cédulas de 20: {0}                 #", qtda20);
            Console.WriteLine("  #   Quantidade de cédulas de 10: {0}                 #", qtda10);
            Console.WriteLine("  #   Quantidade de cédulas de  5: {0}                 #", qtda5);
            Console.WriteLine("  #   Quantidade de cédulas de  2: {0}                 #", qtda2);
            Console.WriteLine("  ####################################################");
        }
    }
}
