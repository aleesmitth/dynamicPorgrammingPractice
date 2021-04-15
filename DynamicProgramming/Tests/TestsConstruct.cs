using System;
using System.Linq;
using NUnit.Framework;

namespace TestProject1 {
    public class TestsConstruct {
        public class ConstructTests {

            [Test]
            public void test07CanConstructMemoize() {
                Assert.True(CanConstruct.Memoize("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
                Assert.False(
                    CanConstruct.Memoize("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
                Assert.True(CanConstruct.Memoize("", new[] {"cat", "dog", "mouse"}));
                Assert.True(CanConstruct.Memoize("enterapotentpot",
                    new[] {"a", "p", "ent", "enter", "ot", "o", "t"}));
                Assert.False(CanConstruct.Memoize("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                    new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
                Assert.False(CanConstruct.Memoize("aasasaadasdasdasdhasdasdasddasasdasdasdaasdasdjk",
                    new[] {"a", "bc", "x", "sd", "e", "z"}));
            }

            [Test]
            public void test02CanConstructTabulation() {
                Assert.True(CanConstruct.Tabulation("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
                Assert.False(CanConstruct.Tabulation("skateboard",
                    new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
                Assert.True(CanConstruct.Tabulation("", new[] {"cat", "dog", "mouse"}));
                Assert.True(CanConstruct.Tabulation("enterapotentpot",
                    new[] {"a", "p", "ent", "enter", "ot", "o", "t"}));
                Assert.False(CanConstruct.Tabulation("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                    new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
                Assert.False(CanConstruct.Tabulation("aasasaadasdasdasdhasdasdasddasasdasdasdaasdasdjk",
                    new[] {"a", "bc", "x", "sd", "e", "z"}));
            }
        }

        public class CountConstructTests {

            [Test]
            public void test01CountConstructMemoize() {
                Assert.AreEqual(1, CountConstruct.Memoize("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
                Assert.AreEqual(0,
                    CountConstruct.Memoize("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
                Assert.AreEqual(1, CountConstruct.Memoize("", new[] {"cat", "dog", "mouse"}));
                Assert.AreEqual(4,
                    CountConstruct.Memoize("enterapotentpot", new[] {"a", "p", "ent", "enter", "ot", "o", "t"}));
                Assert.AreEqual(2, CountConstruct.Memoize("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
                Assert.AreEqual(0, CountConstruct.Memoize("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                    new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
                Assert.AreEqual(0, CountConstruct.Memoize("aasasaadasdasdasdhasdasdasddasasdasdasdaasdasdjk",
                    new[] {"a", "bc", "x", "sd", "e", "z"}));
            }

            [Test]
            public void test02CountConstructTabulation() {
                Assert.AreEqual(1, CountConstruct.Tabulation("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
                Assert.AreEqual(0,
                    CountConstruct.Tabulation("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
                Assert.AreEqual(1, CountConstruct.Tabulation("", new[] {"cat", "dog", "mouse"}));
                Assert.AreEqual(4,
                    CountConstruct.Tabulation("enterapotentpot", new[] {"a", "p", "ent", "enter", "ot", "o", "t"}));
                Assert.AreEqual(2, CountConstruct.Tabulation("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
                Assert.AreEqual(0, CountConstruct.Tabulation("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                    new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
                Assert.AreEqual(0, CountConstruct.Tabulation("aasasaadasdasdasdhasdasdasddasasdasdasdaasdasdjk",
                    new[] {"a", "bc", "x", "sd", "e", "z"}));
            }
        }

        public class AllConstructTests {

            [Test]
            public void test01AllConstructMemoize() {
                var answer = AllConstruct.Memoize("asd", new[] {"a", "s", "d", "as", "sd"});
                foreach (var word in answer.SelectMany(list => list)) {
                    Console.WriteLine(word);
                }

                Assert.IsNull(AllConstruct.Memoize("asd", new[] {"x", "z", "v", "gs", "sd"}));

                Assert.IsNull(AllConstruct.Memoize("skateboard",
                    new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));

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

            [Test]
            public void test02AllConstructTabulation() {
                var answer = AllConstruct.Tabulation("asd", new[] {"a", "s", "d", "as", "sd"});
                foreach (var word in answer.SelectMany(list => list)) {
                    Console.WriteLine(word);
                }

                Assert.IsNull(AllConstruct.Tabulation("asd", new[] {"x", "z", "v", "gs", "sd"}));

                Assert.IsNull(
                    AllConstruct.Tabulation("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));

                answer = AllConstruct.Tabulation("", new[] {"cat", "dog", "mouse"});
                foreach (var word in answer.SelectMany(list => list)) {
                    Console.WriteLine(word);
                }

                answer = AllConstruct.Tabulation("enterapotentpot",
                    new[] {"a", "p", "ent", "enter", "ot", "o", "t"});
                foreach (var word in answer.SelectMany(list => list)) {
                    Console.WriteLine(word);
                }

                answer = AllConstruct.Tabulation("purple", new[] {"purp", "p", "ur", "le", "purpl"});
                foreach (var word in answer.SelectMany(list => list)) {
                    Console.WriteLine(word);
                }

                Assert.IsNull(AllConstruct.Tabulation("eeeeeeeeeeeeeeef",
                    new[] {"e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee"}));
            }
        }
    }
}