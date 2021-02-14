using System.Collections;
using System.Collections.Generic;

namespace TestProject1 {
    public class HowSum {
        
        /// <summary>
        /// returns linked list with the elements if you can achieve the given sum with the elements in the array, no restrictions on the elements.
        /// </summary>
        public static LinkedList<int> Memoize(int sum, int[] array, Dictionary<int, LinkedList<int>> memoize = null) {
            memoize ??= new Dictionary<int, LinkedList<int>>();
            if (memoize.ContainsKey(sum)) return memoize[sum];
            if (sum == 0) return new LinkedList<int>();
            if (sum < 0) return null;

            foreach (var number in array) {
                var list = Memoize(sum - number, array, memoize);
                if (list == null) continue;
                list.AddFirst(number);
                memoize[sum] = list;
                return list;
            }

            memoize[sum] = null;
            return null;
        }
    }
}