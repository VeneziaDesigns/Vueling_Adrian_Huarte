using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_DateTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region booleano
            string trueOrFalse;
            bool valTof = false;

            do
            {
                Console.WriteLine("Introduce un valor boobleano");
                trueOrFalse = Console.ReadLine();

                if (trueOrFalse.Equals("true", StringComparison.OrdinalIgnoreCase) || trueOrFalse.Equals("false", StringComparison.OrdinalIgnoreCase))
                {
                    valTof = true;
                }
                else
                {
                    Console.WriteLine("Introduce un valor válido, debe ser true o false");
                }
            } while (valTof == false);

            bool negacion = bool.Parse(trueOrFalse);

            Console.WriteLine($"La negacion de el booleano introducido es {!negacion}");
            #endregion

            #region division
            int numeroEntero;
            decimal numeroDecimal;
            bool validarNumE = false;
            bool validarNumD = false;

            do
            {
                Console.WriteLine("Introduce un número entero");
                string numE = Console.ReadLine();

                Console.WriteLine("Introduce un número decimal");
                string numD = Console.ReadLine();

                if (int.TryParse(numE, out numeroEntero))
                {
                    validarNumE = true;
                }
                if (decimal.TryParse(numD, out numeroDecimal))
                {
                    validarNumD = true;
                }
            } while ((validarNumE && validarNumD) != true);

            Console.WriteLine($"El resultado de dividir {numeroEntero} entre {numeroDecimal} es {numeroEntero / numeroDecimal}");
            #endregion


            #region texto con caracter introducido
            string character;
            string text;
            do
            {
                Console.WriteLine("Introduce un carácter para añadirlo al texto");
                character = Console.ReadLine();

                Console.WriteLine("Introduce el texto");
                text = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(text) || character.Length != 1);

            Console.WriteLine($"El texto introducido con el caracter al principio y al final: {character + text + character}");
            #endregion

            #region DateTime         
            DateTime resultado = DateTime.Now;
            bool fechaValida = false;

            do
            {
                Console.WriteLine("Introduce una fecha en formato yyyy,mm,dd");
                string fechaIn = Console.ReadLine();

                if (DateTime.TryParse(fechaIn, out DateTime fecha))
                {
                    fechaValida = true;

                    DateTime SumarMes = DateTime.Parse(fechaIn).AddMonths(1).Date;

                    DateTime restarDias = SumarMes.AddDays(-SumarMes.Day + 1);

                    resultado = restarDias.AddSeconds(-1);
                }
                else
                {
                    Console.WriteLine("La fecha introducida no es valida");
                }
            } while (!fechaValida);

            Console.WriteLine("Resultado: " + resultado);

            Console.ReadKey();
            #endregion
        }
    }
}
