using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuenta_bancaria_multi_usuario__Versión_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cuenta = new List<int> { 1, 2, 3, 4, 5 };
            List<int> pin = new List<int> { 1111, 2222, 3333, 4444, 5555 };
            List<decimal> gastos = new List<decimal>();
            List<decimal> ingresos = new List<decimal>();
            decimal saldo = 1000;
            decimal cantidad;
            bool exit = false;
            bool validacion = false;
            bool validInput;
            int nCuenta = 0; ;
            int nPin = 0;
            int posicionCuenta;
            int posicionPin;
            int input;

            do
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Ingrese su nº de cuenta");
                        nCuenta = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese su pin");
                        nPin = int.Parse(Console.ReadLine());
                        validacion = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                } while (!validacion);

                posicionCuenta = cuenta.IndexOf(nCuenta);
                posicionPin = pin.IndexOf(nPin);

                if (nCuenta < 1 || nCuenta > 5)
                {
                    Console.WriteLine("El nº de cuenta no existe");
                }
                if (posicionCuenta != posicionPin)
                {
                    Console.WriteLine("El nº de cuenta y el pin no coinciden");
                }
            } while (posicionCuenta != posicionPin || nCuenta < 1 || nCuenta > 5);

            do
            {
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
                    validInput = int.TryParse(Console.ReadLine(), out input);
                    if (!validInput)
                    {
                        Console.WriteLine("El formato no es valido, seleccione una opcion de la lista");
                    }
                } while (!validInput);

                switch (input)
                {
                    case 1:
                        Console.WriteLine("¿Cuanto dinero desea ingresar?");
                        bool IngresoValido = decimal.TryParse(Console.ReadLine(), out cantidad);

                        if (IngresoValido)
                        {
                            saldo += cantidad;
                            ingresos.Add(cantidad);
                        }
                        else
                        {
                            Console.WriteLine("La cantidad introducida no es valida");
                        }
                        break;
                    case 2:
                        Console.WriteLine("¿Cuanto dinero desea retirar?");
                        bool GastoValido = decimal.TryParse(Console.ReadLine(), out cantidad);

                        if (GastoValido)
                        {
                            if (saldo - cantidad >= 0)
                            {
                                saldo -= cantidad;
                                gastos.Add(cantidad);
                            }
                            else
                            {
                                Console.WriteLine($"Su saldo actual es de {saldo} euros, no hay fondos suficientes");
                            }
                        }
                        else
                        {
                            Console.WriteLine("La cantidad introducida no es valida");
                        }
                        break;
                    case 3:
                        if (ingresos.Count > 0)
                        {
                            Console.WriteLine("Ingresos:");
                            foreach (decimal i in ingresos)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun ingreso");
                        }

                        if (gastos.Count > 0)
                        {
                            Console.WriteLine("Gastos:");
                            foreach (decimal g in gastos)
                            {
                                Console.WriteLine(g);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun gasto");
                        }
                        break;
                    case 4:
                        if (ingresos.Count > 0)
                        {
                            Console.WriteLine("Ingresos:");
                            foreach (decimal i in ingresos)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun ingreso");
                        }
                        break;
                    case 5:
                        if (gastos.Count > 0)
                        {
                            Console.WriteLine("Gastos:");
                            foreach (decimal g in gastos)
                            {
                                Console.WriteLine(g);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun gasto");
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

            } while (exit == false);
        }
    }
}
