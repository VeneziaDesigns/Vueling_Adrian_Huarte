using System;
using System.Collections.Generic;
using cuenta_bancaria_multi_usuario_aplicando_OOP.Account;

namespace cuenta_bancaria_multi_usuario_aplicando_OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool validAccount;
            bool validPass;
            int accountNumber;
            int passNumber;
            int contador = 0;

            Dictionary<int, int> users = Cuenta.InitializeUsers();


            do
            {

                Console.WriteLine("Introduce un numero de cuenta");
                validAccount = int.TryParse(Console.ReadLine(), out accountNumber);

                Console.WriteLine("Introduce el pin");
                validPass = int.TryParse(Console.ReadLine(), out passNumber);

                if ((validAccount && validPass) != true)
                {
                    Console.WriteLine("El numero de cuenta o el pin no tiene un formato valido");
                }

                contador++;

            } while (!(validAccount && validPass) && contador <= 2);



            if ((validAccount && validPass) == true)
            {


                if (accountNumber > 0 && accountNumber < 5)
                {
                    Cuenta cuenta = new Cuenta(accountNumber, passNumber);

                    if (users.ContainsKey(cuenta.pass) && users[cuenta.pass] == cuenta.account)
                    {

                        Console.WriteLine("Acceso concedido");

                        cuenta.Operaciones(cuenta);
                    }
                    else
                    {
                        Console.WriteLine("Pin incorecto");
                    }
                }
                else
                {
                    Console.WriteLine("El número de cuenta no corresponde a ningun cliente");
                }
            }
            else
            {
                Console.WriteLine("Número de intentos sobrepasado");
            }
            Console.ReadKey();
        }
    }
}
