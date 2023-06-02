using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMain.Family
{
    internal class Grandfather
    {
        public string grandfatherName;
        protected int grandfatherAge;
        private string grandfatherDNI;

        public string GetGrandFatherDNI()
        {
            return grandfatherDNI;
        }
        public void SetGrandFatherDNI(string grandfatherDNI)
        {
            this.grandfatherDNI = grandfatherDNI;
        }
    }
}
