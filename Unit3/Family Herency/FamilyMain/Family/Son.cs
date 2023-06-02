using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMain.Family
{
    internal class Son : Father
    {
        public string sonName;
        protected int sonAge;
        private string sonDNI;

        public Son(string sonName, int sonAge, string sonDNI,
                    string fatherName, int fatherAge, string fatherDNI,
                    string grandfatherName, int grandfatherAge, string grandfatherDNI)
        {
            this.sonName = sonName;
            this.sonAge = sonAge;
            this.sonDNI = sonDNI;
            this.fatherName = fatherName;
            this.fatherAge = fatherAge;
            SetFatherDNI(fatherDNI);
            this.grandfatherName = grandfatherName;
            this.grandfatherAge = grandfatherAge;
            SetGrandFatherDNI(grandfatherDNI);
        }
        public void ShowFields()
        {
            Console.WriteLine("Grandfather fields:");
            Console.WriteLine($"Grandfather Name: {base.grandfatherName}");
            Console.WriteLine($"Grandfather Age: {base.grandfatherAge}");
            Console.WriteLine($"Grandfather Dni: {GetGrandFatherDNI()}");

            Console.WriteLine("Father fields:");
            Console.WriteLine($"Father Name: {base.fatherName}");
            Console.WriteLine($"Father Age: {base.fatherAge}");
            Console.WriteLine($"Father Dni: {GetFatherDNI()}");

            Console.WriteLine("Son fields:");
            Console.WriteLine($"Son Name: {this.sonName}");
            Console.WriteLine($"Son Age: {this.sonAge}");
            Console.WriteLine($"Son Dni: {this.sonDNI}");
        }
        public void SetFields()
        {
            Console.WriteLine("Enter values for:");

            Console.WriteLine("grandfatherName");
            grandfatherName = Console.ReadLine();

            Console.WriteLine("grandfatherAge");
            bool grandfatherValid = int.TryParse(Console.ReadLine(), out int edadAbuelo);
            grandfatherAge = edadAbuelo;

            Console.WriteLine("grandfatherDNI");
            SetGrandFatherDNI(Console.ReadLine());

            Console.WriteLine("fatherName");
            fatherName = Console.ReadLine();

            Console.WriteLine("fatherAge");
            bool fatherValid = int.TryParse(Console.ReadLine(), out int edadPadre);
            grandfatherAge = edadPadre;

            Console.WriteLine("fatherDNI");
            SetFatherDNI(Console.ReadLine());

            Console.WriteLine("sonName");
            sonName = Console.ReadLine();

            Console.WriteLine("sonAge");
            bool sonValid = int.TryParse(Console.ReadLine(), out int edadHijo);
            grandfatherAge = edadHijo;

            Console.WriteLine("sonDNI");
            sonDNI = Console.ReadLine();

            Console.WriteLine("Modified values");

            ShowFields();
        }
    }
}
