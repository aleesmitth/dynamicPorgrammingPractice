using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace TestProject1 {
    public class Tests {
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
        public void test03GridTravelerMemoize() {
            Assert.AreEqual(1, GridTraveler.Travel(1,1));
            Assert.AreEqual(1, GridTraveler.Travel(1,2));
            Assert.AreEqual(2, GridTraveler.Travel(2,2));
            Assert.AreEqual(3, GridTraveler.Travel(3,2));
            Assert.AreEqual(2333606220, GridTraveler.Travel(18,18));
        }
        
        [Test]
        public void test04CanSumMemoize() {
            Assert.False(CanSum.Memoize(7, new[] {2, 4}));
            Assert.True(CanSum.Memoize(8, new[] {2, 4}));
            Assert.False(CanSum.Memoize(7, new[] {2, 4, 6, 8, 50}));
            Assert.False(CanSum.Memoize(300, new[] {7, 14}));
        }
        
        [Test]
        public void test05HowSumMemoize() {
            var list = default(LinkedList<int>);
            list = HowSum.Memoize(5, new[] {2, 3, 10});
            Assert.AreEqual(5, list.Sum());
            list = HowSum.Memoize(10, new[] {2, 3, 6});
            Assert.AreEqual(10, list.Sum());
            list = HowSum.Memoize(20, new[] {2, 3, 4});
            Assert.AreEqual(20, list.Sum());
            list = HowSum.Memoize(300, new[] {7, 14});
            Assert.IsNull(list);
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