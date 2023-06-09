using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  Domain Entities

namespace Domain
{
    public class Outcome
    {
        public decimal outcomes { get; set; }

        public Outcome(decimal money)
        {
            outcomes = money;
        }

        public Outcome()
        {
         
        }

        public override string ToString()
        {
            return $"{outcomes} euros";
        }
    }
}
