using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

//  Domain Entities

namespace Domain
{
    public class Income
    {
        public decimal incomes { get; set; }

        public Income(decimal money)
        {
            incomes = money;
        }

        public Income()
        {

        }

        public override string ToString()
        {
            return $"{incomes} euros";
        }
    }
}
