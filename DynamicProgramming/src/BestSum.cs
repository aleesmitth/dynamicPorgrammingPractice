using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestProject1 {
    public class BestSum {
        
        /// <summary>
        /// returns list with min amount of elements from the arrya needed to get the sum. 
        /// </summary>
        public static LinkedList<int> Memoize(int sum, int[] array, Dictionary<int, LinkedList<int>> memoize = null) {
            memoize ??= new Dictionary<int, LinkedList<int>>();
            if (memoize.ContainsKey(sum)) {
                //if i dont make a copy, i'll risk modifying the stored list.
                return MakeCopyOfList(memoize[sum]);
            }
            if (sum == 0) return new LinkedList<int>();
            if (sum < 0) return null;

            LinkedList<int> shortestList = null;
            foreach (var number in array) {
                var list = Memoize(sum - number, array, memoize);
                if (list == null) continue;
                list.AddFirst(number);
                if (shortestList == null || list.Count < shortestList.Count) {
                    shortestList = list;
                }
            }

            if (shortestList == null) return null;
            memoize[sum] = shortestList;
            //if i dont make a copy, i'll risk modifying the stored list.
            return MakeCopyOfList(shortestList);
        }
        
        public static LinkedList<int> Tabulation(int sum, int[] array) {
            LinkedList<int>[] table = new LinkedList<int>[sum + 1];
            table[0] = new LinkedList<int>();
            for (int i = 0; i < table.Length; i++) {
                if(table[i] == null) continue;
                foreach (var number in array) {
                    if(i + number >= table.Length) continue;
                    var newCombination = new LinkedList<int>(table[i]);
                    newCombination.AddFirst(number);
                    table[i + number] ??= newCombination;
                    if (newCombination.Count > table[i + number].Count) continue;
                    table[i + number] = newCombination;
                }
            }

            return table[sum];
        }

        /// <summary>
        /// makes a copy of the received list and returns it.
        /// </summary>
        private static LinkedList<T> MakeCopyOfList<T>(LinkedList<T> list) {
            LinkedList<T> bufferList = new LinkedList<T>(list);
            return bufferList;
        }
    }
}