using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace cuenta_bancaria_multi_usuario_aplicando_OOP.Cash
{
    internal class Incomes : Money
    {
        public Incomes(decimal money) : base(money)
        {
        }
        public override string ToString()
        {
            return $"{money} euros";
        }
    }
}
