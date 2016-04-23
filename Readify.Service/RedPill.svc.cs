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
            Array.Reverse(wordArray);
            var output = new string(wordArray);
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
    }
}
