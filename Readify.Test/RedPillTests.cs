using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readify.Service;

namespace Readify.Test
{
    [TestClass]
    public class RedPillTests
    {
        [TestMethod]
        public void ReverseWordTest()
        {
            string word = "mytestword";
            string expectedResult = "drowtsetym";

            var svc = new MyRedPill();
            var result = svc.ReverseWords(word);

            Assert.AreEqual(expectedResult, result, "word reversal incorrect");
        }

        [TestMethod]
        public void FibonacciNumberTest()
        {
            var svc = new MyRedPill();

            var result = svc.FibonacciNumber(3);
            Assert.AreEqual(2, result, "Fibonacci calculation incorrect");
            
            result = svc.FibonacciNumber(-5);
            Assert.AreEqual(-5, result, "Fibonacci calculation incorrect");

            result = svc.FibonacciNumber(0);
            Assert.AreEqual(0, result, "Fibonacci calculation incorrect");

            result = svc.FibonacciNumber(1);
            Assert.AreEqual(1, result, "Fibonacci calculation incorrect");

            result = svc.FibonacciNumber(6);
            Assert.AreEqual(8, result, "Fibonacci calculation incorrect");
        }

        [TestMethod]
        public void FibonacciNumberExceptionTest()
        {
            var svc = new MyRedPill();

            try
            {
                var result = svc.FibonacciNumber(95);                
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Fib(>92) will cause a 64-bit integer overflow.", ex.Message);
            }
        }

        [TestMethod]
        public void WhatShapeIsThisTest()
        {
            var svc = new MyRedPill();

            //equilateral
            int a, b, c;
            a=b=c = 10;
            var output = svc.WhatShapeIsThis(a,b,c);
            Assert.AreEqual(TriangleType.Equilateral, output, "Equilateral check failed");

            //isosceles
            a = 5;
            b = 5;
            c = 8;
            output = svc.WhatShapeIsThis(a, b, c);
            Assert.AreEqual(TriangleType.Isosceles, output, "Isosceles check failed");

            //scalene
            a = 5;
            b = 6;
            c = 10;
            output = svc.WhatShapeIsThis(a, b, c);
            Assert.AreEqual(TriangleType.Scalene, output, "Scalene check failed");
            
            //error
            a = 5;
            b = 5;
            c = 11;
            output = svc.WhatShapeIsThis(a, b, c);
            Assert.AreEqual(TriangleType.Error, output, "Error check failed");
        }
    }
}
