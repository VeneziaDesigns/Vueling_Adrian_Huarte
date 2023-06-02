using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Infrastructure.Data;

namespace Presentation.Authentication
{
    public class Autenticacion
    {
        public bool StartAuthentication()
        {
            Console.WriteLine("Please enter the account number");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("please enter the pin number");
            string pinNumber = Console.ReadLine();

            (bool isParseableAccount, int parsedIncomeAccount) = new Parsing().TryParseIntValue(accountNumber);
            (bool isParseablePass, int parsedIncomePass) = new Parsing().TryParseIntValue(pinNumber);

            if (isParseableAccount && isParseablePass)
            {
                bool checkData = CheckData(parsedIncomeAccount, parsedIncomePass);
                return checkData;
            }
            else
            {
                Console.WriteLine("The format is not correct");
                return false;
            }
        }

        public bool CheckData(int accountNumber, int passNumber)
        {
            Dictionary<int, int> users = new InfrastructureData().InitializeUsers();

            if (accountNumber > 0 && accountNumber < 6)
            {
                Account cuenta = new Account(accountNumber, passNumber);

                if (users.ContainsKey(cuenta.pass) && users[cuenta.pass] == cuenta.account)
                {
                    Console.WriteLine("Access granted");
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect account number or password");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The account number does not correspond to any customer.");
                return false;
            }
        }
    }
}
