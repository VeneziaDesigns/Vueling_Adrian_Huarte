using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuenta_bancaria_multi_usuario_aplicando_OOP.Cash
{
    abstract class Money
    {
        public decimal money { get; set; }

        public Money(decimal money)
        {
            this.money = money;
        }
    }
}
