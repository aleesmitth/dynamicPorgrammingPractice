using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace TestProject1 {
    public class Tests {
        public class FibonacciTests {

            [Test]
            public void test01FibonacciMemoize() {
                var fibonacciNumbers = FibonacciNumbers();
                for (int i = 0; i <= 9; i++) {
                    Assert.AreEqual(fibonacciNumbers[i], Fibonacci.Memoize(i));
                }
                Assert.AreEqual(12586269025, Fibonacci.Memoize(50));
            }
            
            
        
            [Test]
            public void test02FibonacciBottomUp() {
                var fibonacciNumbers = FibonacciNumbers();
                for (int i = 0; i <= 9; i++) {
                    Assert.AreEqual(fibonacciNumbers[i], Fibonacci.BottomUp(i));
                }
                Assert.AreEqual(12586269025, Fibonacci.BottomUp(50));
            }
        
            [Test]
            public void test03FibonacciTabulation() {
                var fibonacciNumbers = FibonacciNumbers();
                for (int i = 0; i <= 9; i++) {
                    Assert.AreEqual(fibonacciNumbers[i], Fibonacci.Tabulation(i));
                }
                Assert.AreEqual(12586269025, Fibonacci.Tabulation(50));
            }

            private int[] FibonacciNumbers() {
                int[] fibonacciNumbers = new int[99];
                fibonacciNumbers[0] = 0;
                fibonacciNumbers[1] = 1;
                fibonacciNumbers[2] = 1;
                fibonacciNumbers[3] = 2;
                fibonacciNumbers[4] = 3;
                fibonacciNumbers[5] = 5;
                fibonacciNumbers[6] = 8;
                fibonacciNumbers[7] = 13;
                fibonacciNumbers[8] = 21;
                fibonacciNumbers[9] = 34;
                return fibonacciNumbers;
            }
        }
    }
}