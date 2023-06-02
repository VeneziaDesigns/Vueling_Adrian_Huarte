using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuenta_bancaria_mono_usuario__Versión_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> ingresos = new List<decimal>();
            List<decimal> gastos = new List<decimal>();
            decimal saldo = 1000;
            decimal cantidad;
            bool exit = false;


            do
            {
                Console.WriteLine($"Su saldo actual es de {saldo} euros");
                Console.WriteLine("¿Que operacion desea realizar?");
                Console.WriteLine("1 -Money income");
                Console.WriteLine("2 -Money outcome");
                Console.WriteLine("3 -List all movements");
                Console.WriteLine("4 -List incomes");
                Console.WriteLine("5 -List outcomes");
                Console.WriteLine("6 -Show current money");
                Console.WriteLine("7 -Exit");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("¿Cuanto dinero desea ingresar?");
                        cantidad = decimal.Parse(Console.ReadLine());
                        saldo += cantidad;
                        ingresos.Add(cantidad);
                        break;
                    case 2:
                        Console.WriteLine("¿Cuanto dinero desea retirar?");
                        cantidad = decimal.Parse(Console.ReadLine());
                        if (saldo - cantidad >= 0)
                        {
                            saldo -= cantidad;
                            gastos.Add(cantidad);
                        }
                        else
                        {
                            Console.WriteLine($"Su saldo actual es de {saldo} euros, no hay fondos suficientes");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ingresos:");
                        foreach (decimal i in ingresos)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("Gastos:");
                        foreach (decimal g in gastos)
                        {
                            Console.WriteLine(g);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ingresos:");
                        foreach (decimal i in ingresos)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Gastos:");
                        foreach (decimal g in gastos)
                        {
                            Console.WriteLine(g);
                        }
                        break;
                    case 6:
                        Console.WriteLine($"Su saldo actual es de {saldo} euros");
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("El nº introducido no corresponde a ninguna opcion");
                        break;
                }
                Console.WriteLine("¿Desea realizar alguna otra operacion?");
                Console.WriteLine("1 - Si");
                Console.WriteLine("2 - No");
                int moreOperations = int.Parse(Console.ReadLine());

                if (moreOperations == 2)
                {
                    exit = true;
                    Console.WriteLine($"Su saldo actual es de {saldo} euros");
                }
                else
                {
                    exit = false;
                }

            } while (exit == false);
        }
    }
}
