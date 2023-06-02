using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cuenta_bancaria_multi_usuario_aplicando_OOP.Cash;

namespace cuenta_bancaria_multi_usuario_aplicando_OOP.Account
{
    internal class Cuenta
    {
        public int account { get; set; }
        public int pass { get; set; }
        public decimal balance { get; set; }
        public List<Incomes> incomes { get; set; }
        public List<Outcomes> outcomes { get; set; }

        public Cuenta(int account, int pass)
        {
            this.account = account;
            this.pass = pass;
            this.balance = 1000;
            this.incomes = new List<Incomes>();
            this.outcomes = new List<Outcomes>();
        }
        public void AddIncomes(decimal cash)
        {
            this.balance += cash;

            incomes.Add(new Incomes(cash));

            Console.WriteLine($"Su saldo actual es de {balance}");
        }
        public void AddOutcomes(decimal cash)
        {
            if (balance < cash)
            {
                Console.WriteLine("El saldo de la cuenta es insuficiente");
            }
            else
            {
                this.balance -= cash;

                outcomes.Add(new Outcomes(cash));

                Console.WriteLine($"Su saldo actual es de {balance}");
            }
        }
        public static Dictionary<int, int> InitializeUsers()
        {
            Dictionary<int, int> users = new Dictionary<int, int>()
            {
                { 1111, 1 },
                { 2222, 2 },
                { 3333, 3 },
                { 4444, 4 },
                { 5555, 5 },
            };
            return users;
        }

        public void Operaciones(Cuenta cuenta)
        {
            int input;
            decimal cantidad;
            bool exit = false;
            bool validInput;

            Console.WriteLine(cuenta.ToString());

            do
            {
                do
                {

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
                            cuenta.AddIncomes(cantidad);
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
                            cuenta.AddOutcomes(cantidad);
                        }
                        else
                        {
                            Console.WriteLine("La cantidad introducida no es valida");
                        }
                        break;
                    case 3:
                        if (cuenta.incomes.Count > 0)
                        {
                            Console.WriteLine("Ingresos:");
                            foreach (Incomes i in cuenta.incomes)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay ningun ingreso");
                        }

                        if (cuenta.outcomes.Count > 0)
                        {
                            Console.WriteLine("Gastos:");
                            foreach (Outcomes g in cuenta.outcomes)
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
                        if (cuenta.incomes.Count > 0)
                        {
                            Console.WriteLine("Ingresos:");
                            foreach (Incomes i in cuenta.incomes)
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
                        if (cuenta.outcomes.Count > 0)
                        {
                            Console.WriteLine("Gastos:");
                            foreach (Outcomes g in cuenta.outcomes)
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
                        Console.WriteLine(cuenta.ToString());
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("El nº introducido no corresponde a ninguna opcion");
                        break;
                }
            } while (!exit);


            Console.WriteLine("Hasta otra");

        }
        public override string ToString()
        {
            return $"El saldo es de {balance}";
        }
    }
}
