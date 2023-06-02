using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuenta_bancaria_multi_usuario_aplicando_OOP.Cash
{
    internal class Outcomes : Money
    {
        public Outcomes(decimal money) : base(money)
        {
        }

        public override string ToString()
        {
            return $"{money} euros";
        }
    }
}
