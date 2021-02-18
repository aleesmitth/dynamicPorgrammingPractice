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
            return MakeCopyOfList(shortestList);;
        }

        /// <summary>
        /// makes a copy of the received list and returns it.
        /// </summary>
        private static LinkedList<T> MakeCopyOfList<T>(LinkedList<T> list) {
            LinkedList<T> bufferList = new LinkedList<T>();
            foreach (var element in list) {
                bufferList.AddLast(element);
            }

            return bufferList;
        }
    }
}