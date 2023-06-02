using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMain.Family
{
    internal class Father : Grandfather
    {
        public string fatherName;
        protected int fatherAge;
        private string fatherDNI;

        public string GetFatherDNI()
        {
            return fatherDNI;
        }
        public void SetFatherDNI(string fatherDNI)
        {
            this.fatherDNI = fatherDNI;
        }
    }
}
