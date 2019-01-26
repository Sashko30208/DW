using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2
{
    interface IChecker
    {
        int BracketsCount { get; set; }
        string InFunc { get; set; }
        bool Result { get; set; }
        void IsOk(string s);
    }
    public class Checker//:IChecker
    {
        //Create an array with brackets
        //**Don't forget to update "BracketsCount" if U wanna change a count of brackets in Array (brackets)**
        static readonly int BracketsCount = 6;
        readonly char[] brackets = new char[6] {'(',')','{','}','[',']'};
        Stack<int> stackWithBrackets = new Stack<int>();//It's used to save a count of bracket and check its compatibility
     
        /// <summary>
        /// if isOk=-1: necessary opening bracket is not exist;
        /// if isOk = -2: Not All brackets are closed;
        /// if isOk = 0 : Ok;
        /// </summary>
        int isOk =0;
        //Its returns a number of bracket in array 'brackets'
        int BrackNum(char c)
        {
            //It might be faster with using switch(case), but I wanna use a loop
            for (int i = 0; i < BracketsCount; )
            {
                if (c == brackets[i]) return i;
                i++;
            }
            return -1;
        }
        
        /// <summary>
        /// This variable is need to combine all method of class and give a result of checking
        /// </summary>
        /// <param name="input">function with brackets</param>
        /// <returns>Are brackets in right place or not</returns>
        public string IsBracketsAreOk(string input)
        {
            Check(input);
            switch (isOk)
            {
                case 0: return "All is good with brackets";
                case -1: return "Necessary opening bracket is not found";
                case -2: return "Not All brackets are closed";
                default: return "fatalerror";
            }
        }
      
        /// <summary>
        /// This method need to change a value of 'isOk'.
        /// </summary>
        /// <param name="inFunc">Checking param.</param>
        public void Check (string inFunc)
        {
            int len = inFunc.Length;
            int num;//A number of bracket in array "brackets".
            //Checking every char and Push/Pop when its need to.
            for (int i=0; i<len;i++)
            {
                if((num = BrackNum(inFunc[i]) )>= 0) //thue =>it's a bracket.
                {
                    if (num % 2 == 0)
                        stackWithBrackets.Push(num);
                    else
                    if (stackWithBrackets.Count() > 0)
                    {
                        if (stackWithBrackets.Pop() != num - 1)
                        {
                            isOk = -1; break;
                        }
                    }
                    else { isOk = -1; break; }      
                }
            }
            if (stackWithBrackets.Count != 0)
                isOk = -2;
        }

    }
}
