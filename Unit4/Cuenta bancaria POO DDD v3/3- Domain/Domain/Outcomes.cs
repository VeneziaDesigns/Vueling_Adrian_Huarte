using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Outcomes
    {
        public decimal outcomes { get; set; }

        public Outcomes(decimal money)
        {
            outcomes = money;
        }

        public override string ToString()
        {
            return $"{outcomes} euros";
        }
    }
}
