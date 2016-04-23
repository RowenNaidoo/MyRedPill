using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Readify.Service
{
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPill : IRedPill
    {
        public string ReverseWords(string s)
        {
            if(s == null)
            {
                var fault = new ArgumentNullExceptionFault();

                fault.FaultMessage = "Value cannot be null.";

                throw new FaultException<ArgumentNullExceptionFault>(fault, fault.FaultMessage); 
            }

            var wordArray = s.ToCharArray();
            char[] reversedWord = new char[wordArray.Length];
            //char[] temp = new char[wordArray.Length];
            var tempString = new StringBuilder();
            int rCounter = 0;
            var cond = true;

            for (var count = 0; count < wordArray.Length; count++)
            {
                if ((wordArray[count] == Convert.ToChar(" ")))
                {
                    if (count == wordArray.Length - 1)
                    {
                        reversedWord[rCounter] = wordArray[count];

                        if (tempString.Length > 0)
                        {
                            _ReverseWord(tempString, reversedWord, ref rCounter);
                            
                            reversedWord[rCounter] = wordArray[count];
                            rCounter++;

                            tempString.Clear();
                        }
                    }
                    else
                    {
                        if (tempString.Length > 0)
                        {
                            _ReverseWord(tempString, reversedWord, ref rCounter);

                            reversedWord[rCounter] = wordArray[count];
                            rCounter++;

                            tempString.Clear();
                        }
                        else
                        {
                            reversedWord[rCounter] = wordArray[count];
                            rCounter++;
                        }
                    }
                    cond = false;
                }
                else
                {
                    cond = true;
                }
                
                if (cond == true)//no space encountered
                {
                    tempString.Append(wordArray[count]);

                    if (count == wordArray.Length - 1)
                    {
                        _ReverseWord(tempString, reversedWord, ref rCounter);
                        tempString.Clear();
                    }
                }
            }

            var output = new string(reversedWord);
            return output;
        }

        public long FibonacciNumber(long n)
        {
            long fib = 0;
            long temp = 1;
            var count = n;

            if(n < 0)
            {
                count = n * -1;
            }

            try
            {
                checked
                {
                    for (var i = 0; i < count; i++)
                    {
                        fib = fib + temp;
                        temp = fib - temp;
                    }
                }
            }
            catch (OverflowException ex)
            {
                var fault = new ArgumentOutOfRangeExceptionFault();

                fault.FaultMessage = "Fib(>92) will cause a 64-bit integer overflow.";

                throw new FaultException<ArgumentOutOfRangeExceptionFault>(fault, fault.FaultMessage);     
            }
            

            if (n < 0)
            {
                if ((n * -1) % 2 != 0)
                {
                    fib = fib * -1;
                }
            }

            return fib;
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            if ((a + b > c) && (a + c > b) && (b + c > a))
            {
                //triangle sides are valid
                //check for equilateral
                if ((a == b) && (b == c) && (a == c))
                {
                    return TriangleType.Equilateral;
                }

                if ((a == b) || (b == c) || (a == c))
                {
                    return TriangleType.Isosceles;
                }

                if ((a != b) && (b != c) && (a != c))
                {
                    return TriangleType.Scalene;
                }
            }
            return TriangleType.Error;
        }

        public Guid WhatIsYourToken()
        {
            return new Guid("19c6e11c-a8d8-458f-a5fa-2dcfaa935684");
        }

        private void _ReverseWord(StringBuilder tempString, char[] reversedWord, ref int rCounter)
        {
            //reverse word in tempArray
            var tempArray = tempString.ToString().ToCharArray();
            Array.Reverse(tempArray);

            //add to reversedArray
            for (var ra = 0; ra < tempArray.Length; ra++)
            {
                reversedWord[rCounter] = tempArray[ra];
                rCounter++;
            }
        }
    }
}
