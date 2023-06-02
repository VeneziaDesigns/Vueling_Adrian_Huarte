using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Incomes
    {
        public decimal incomes { get; set; }

        public Incomes(decimal money)
        {
            incomes = money;
        }

        public override string ToString()
        {
            return $"{incomes} euros";
        }
    }
}
