using System;
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

        [Test]
        public void test06BestSumMemoize() {
            var list = default(LinkedList<int>);
            //---
            list = BestSum.Memoize(7, new[] {3, 4, 7});
            Assert.AreEqual(7, list.First.Value);
            Console.WriteLine(list.First.Value);
            Console.WriteLine("--");
            //---
            list = BestSum.Memoize(13, new[] {3, 4, 7});
            int[] output = {3, 3, 7};
            var i = 0;
            foreach (var number in list) {
                Assert.AreEqual(output[i], number);
                Console.WriteLine(number);
                i++;
            }
            Console.WriteLine("--");
            //---
            list = BestSum.Memoize(100, new[]{2, 1, 5, 25});
            output = new[] {25, 25, 25, 25};
            foreach (var number in list) {
                Assert.AreEqual(output[i], number);
                Console.WriteLine(number);
            }
            Console.WriteLine("--");
        }

        [Test]
        public void test07CanConstructMemoize() {
            Assert.True(CanConstruct.Memoize("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            Assert.False(CanConstruct.Memoize("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            Assert.True(CanConstruct.Memoize("", new[] {"cat", "dog", "mouse"}));
            Assert.True(CanConstruct.Memoize("enterapotentpot", new[] {"a", "p", "ent", "enter", "ot", "o", "t"}));
            Assert.False(CanConstruct.Memoize("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
            Assert.False(CanConstruct.Memoize("aasasaadasdasdasdhasdasdasddasasdasdasdaasdasdjk",
                new[] {"a", "bc", "x", "sd", "e", "z"}));
        }

        [Test]
        public void test08CountConstructMemoize() {
            Assert.AreEqual(1, CountConstruct.Memoize("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            Assert.AreEqual(0, CountConstruct.Memoize("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            Assert.AreEqual(1, CountConstruct.Memoize("", new[] {"cat", "dog", "mouse"}));
            Assert.AreEqual(4, CountConstruct.Memoize("enterapotentpot", new[] {"a", "p", "ent", "enter", "ot", "o", "t"}));
            Assert.AreEqual(2, CountConstruct.Memoize("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
            Assert.AreEqual(0, CountConstruct.Memoize("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
            Assert.AreEqual(0, CountConstruct.Memoize("aasasaadasdasdasdhasdasdasddasasdasdasdaasdasdjk",
                new[] {"a", "bc", "x", "sd", "e", "z"}));
        }

        [Test]
        public void test09AllConstructMemoize() {
            var answer = AllConstruct.Memoize("asd", new[] {"a", "s", "d", "as", "sd"});
            foreach (var word in answer.SelectMany(list => list)) {
                Console.WriteLine(word);
            }
            Assert.IsNull(AllConstruct.Memoize("asd", new[] {"x", "z", "v", "gs", "sd"}));
            
            Assert.IsNull(AllConstruct.Memoize("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            
            answer = AllConstruct.Memoize("", new[] {"cat", "dog", "mouse"});
            foreach (var word in answer.SelectMany(list => list)) {
                Console.WriteLine(word);
            }
            
            answer = AllConstruct.Memoize("enterapotentpot", new[] {"a", "p", "ent", "enter", "ot", "o", "t"});
            foreach (var word in answer.SelectMany(list => list)) {
                Console.WriteLine(word);
            }
            
            answer = AllConstruct.Memoize("purple", new[] {"purp", "p", "ur", "le", "purpl"});
            foreach (var word in answer.SelectMany(list => list)) {
                Console.WriteLine(word);
            }
            
            Assert.IsNull(AllConstruct.Memoize("eeeeeeeeeeeeeeef",
                new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));

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