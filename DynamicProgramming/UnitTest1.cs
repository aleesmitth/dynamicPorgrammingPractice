using NUnit.Framework;

namespace TestProject1 {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void test01FibonacciMemoizeFrom1To8() {
            var fibonacciNumbers = FibonacciNumbers();
            for (int i = 0; i < 9; i++) {
                var buffer = CreateBuffer();
                Assert.AreEqual(fibonacciNumbers[i], Fibonacci.Memoize(i, buffer));
            }
        }
        [Test]
        public void test02FibonacciBottomUpFrom1To8() {
            var fibonacciNumbers = FibonacciNumbers();
            for (int i = 0; i < 9; i++) {
                Assert.AreEqual(fibonacciNumbers[i], Fibonacci.BottomUp(i, 9));
            }
        }

        private int[] FibonacciNumbers() {
            int[] fibonacciNumbers = new int[99];
            fibonacciNumbers[0] = 1;
            fibonacciNumbers[1] = 1;
            fibonacciNumbers[2] = 2;
            fibonacciNumbers[3] = 3;
            fibonacciNumbers[4] = 5;
            fibonacciNumbers[5] = 8;
            fibonacciNumbers[6] = 13;
            fibonacciNumbers[7] = 21;
            fibonacciNumbers[8] = 34;
            return fibonacciNumbers;
        }

        private int[] CreateBuffer() {
            const int n = 99;
            int[] buffer = new int [n];
            buffer[0]=1;
            buffer[1]=1;
            for(int i = 2; i<n ; i++){
                buffer[i] = 0;
            }

            return buffer;
        }
    }
}