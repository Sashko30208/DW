using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Checker checker = new Checker();
            string func;
            //Console.Write(checker.IsBracketsAreOk("(a+b(fsf)*cos([15]))"));
            Console.WriteLine("This program can only check count of brackets and their correctness of sequence");
            Console.Write("Enter a function:");
            func = Convert.ToString(Console.ReadLine());
            Console.Write(checker.IsBracketsAreOk(func));
            Console.ReadKey();
        }
    }
}
