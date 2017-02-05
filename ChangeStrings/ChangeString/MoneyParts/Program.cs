using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyParts
{
    class Program
    {
        static void Main(string[] args)
        {
            MoneyParts moneyParts = new MoneyParts();
            List<decimal[]> result1 = moneyParts.Build(10.50m);
            foreach (var item in result1)
            {
                Console.WriteLine(String.Format("{0}: /n- {1}", "RESULT", string.Join(",",item)));
            }
           
            Console.ReadLine();
        }
    }
}
