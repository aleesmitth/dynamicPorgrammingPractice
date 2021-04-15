using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1 {
    public class AllConstruct {
        /// <summary>
        /// returns list of lists with all the possible combinations of strings in the array to construct the given target string.
        /// </summary>
        public static LinkedList<LinkedList<string>> Memoize(string target, string[] array, Dictionary<string,LinkedList<LinkedList<string>>> memoize = null) {
            memoize ??= new Dictionary<string, LinkedList<LinkedList<string>>>();
            if (memoize.ContainsKey(target)) return MakeCopyOfList(memoize[target]);
            if (target.Length == 0) return new LinkedList<LinkedList<string>>();
            //keeping track if any answer was found.
            var isPossible = false;
            foreach (var word in array) {
                //if word is not starting substring of target, jump to next word.
                if (target.IndexOf(word, StringComparison.Ordinal) != 0) continue;
                var shortenedTarget = target.Substring(word.Length);
                //recursive call.
                var bufferAnswer = Memoize(shortenedTarget, array, memoize);
                //if its not possible to find answer with substring, jump to next word.
                if(bufferAnswer == null) continue;
                //if null, it means we are adding the first combination of words.
                if (bufferAnswer.First == null) bufferAnswer.AddFirst(new LinkedList<string>());
                isPossible = true;
                //maybe the bufferanswer has already other lists added, need to add the word to those and memoize them.
                if (!memoize.ContainsKey(target)) memoize[target] = new LinkedList<LinkedList<string>>();
                foreach (var list in bufferAnswer) {
                    list.AddFirst(word);
                    memoize[target].AddLast(list);
                }
            }
            //if it was possible return a copy of the memoized list of lists, otherwise it can modify the stored lists.
            return !isPossible ? null : MakeCopyOfList(memoize[target]);
        }

        public static LinkedList<LinkedList<string>> Tabulation(string target, string[] array) {
            LinkedList<LinkedList<string>>[] table = new LinkedList<LinkedList<string>>[target.Length + 1];
            table[0] = new LinkedList<LinkedList<string>>();
            table[0].AddFirst(new LinkedList<string>());

            for (int i = 0; i < target.Length; i++) {
                if(table[i] == null) continue;
                foreach (var listOfWords in table[i]) {
                    foreach (var word in array) {
                        if (word.Length + i > target.Length) continue;
                        if (target.Substring(i, word.Length) != word) continue;
                        table[word.Length + i] ??= new LinkedList<LinkedList<string>>();
                        var newList = new LinkedList<string>(listOfWords);
                        newList.AddLast(word);
                        table[word.Length + i].AddFirst(newList);
                    }
                }
            }

            return table[target.Length];
        }


        /// <summary>
        /// makes a copy of the received list of lists and returns it.
        /// </summary>
        private static LinkedList<LinkedList<T>> MakeCopyOfList<T>(LinkedList<LinkedList<T>> listOfLists) {
            LinkedList<LinkedList<T>> bufferListOfLists = new LinkedList<LinkedList<T>>();
            foreach (var bufferList in listOfLists.Select(list => new LinkedList<T>(list))) { bufferListOfLists.AddLast(bufferList); }
            return bufferListOfLists;
        }
    }
}