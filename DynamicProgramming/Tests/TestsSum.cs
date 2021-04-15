using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestProject1 {
    public class TestsSum {
        public class CanSumTests {
    
            [Test]
            public void test01CanSumMemoize() {
                Assert.False(CanSum.Memoize(7, new[] {2, 4}));
                Assert.True(CanSum.Memoize(8, new[] {2, 4}));
                Assert.False(CanSum.Memoize(7, new[] {2, 4, 6, 8, 50}));
                Assert.False(CanSum.Memoize(300, new[] {7, 14}));
            }

            [Test]
            public void test03CanSumTabulation() {
                Assert.False(CanSum.Tabulation(7, new[] {2, 4}));
                Assert.True(CanSum.Tabulation(8, new[] {2, 4}));
                Assert.False(CanSum.Tabulation(7, new[] {2, 4, 6, 8, 50}));
                Assert.False(CanSum.Tabulation(300, new[] {7, 14}));
            }
        }
        
        public class HowSumTests {
    
            [Test]
            public void test01HowSumMemoize() {
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
            public void test02HowSumTabulation() {
                var list = default(LinkedList<int>);
                list = HowSum.Tabulation(5, new[] {2, 3, 10});
                Assert.AreEqual(5, list.Sum());
                list = HowSum.Tabulation(10, new[] {2, 3, 6});
                Assert.AreEqual(10, list.Sum());
                list = HowSum.Tabulation(20, new[] {2, 3, 4});
                Assert.AreEqual(20, list.Sum());
                list = HowSum.Tabulation(300, new[] {7, 14});
                Assert.IsNull(list);
            }
        }
        
        public class BestSumTests {

            [Test]
            public void test01BestSumMemoize() {
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
            public void test02BestSumTabulation() {
                var list = default(LinkedList<int>);
                //---
                list = BestSum.Tabulation(7, new[] {3, 4, 7});
                Assert.AreEqual(7, list.First.Value);
                Console.WriteLine(list.First.Value);
                Console.WriteLine("--");
                //---
                list = BestSum.Tabulation(13, new[] {3, 4, 7});
                int[] output = {3, 3, 7};
                var i = 0;
                foreach (var number in list) {
                    Assert.AreEqual(output[i], number);
                    Console.WriteLine(number);
                    i++;
                }
                Console.WriteLine("--");
                //---
                list = BestSum.Tabulation(100, new[]{2, 1, 5, 25});
                output = new[] {25, 25, 25, 25};
                foreach (var number in list) {
                    Assert.AreEqual(output[i], number);
                    Console.WriteLine(number);
                }
                Console.WriteLine("--");
            }
        }
    }
}