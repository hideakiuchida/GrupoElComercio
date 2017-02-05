using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeString
{
    class Program
    {
        static void Main(string[] args)
        {
            string args1 = "123 abcd * 3";
            string args2 = "**Casa 52";
            String args3 = "arroz";
            ChangeString changeString = new ChangeString();
            Console.WriteLine(changeString.build(args1));
            Console.WriteLine(changeString.build(args2));
            Console.WriteLine(changeString.build(args3));
            Console.ReadLine();
        }

    }

}
