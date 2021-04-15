using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1 {
    public class CanSum {
        
        /*so here is my solution, but rider recommended to use a LINQ expression, (i use the |= opperand because true || false = true*/
        
        /*public static bool Memoize(int sum, int[] array, Dictionary<int, bool> memoize = null) {
            memoize ??= new Dictionary<int, bool>();
            if(memoize.ContainsKey(sum)) return memoize[sum];
            if (sum < 0) return false;
            if (sum == 0) return true;

            var answer = false;
            foreach (var number in array) {
                answer |= memoize[sum] = Memoize(sum - number, array, memoize);
            }

            return answer;
        }*/
        /// <summary>
        /// returns true or false if you can achieve the given sum with the elements in the array, no restrictions on the elements.
        /// </summary>
        public static bool Memoize(int sum, int[] array, Dictionary<int, bool> memoize = null) {
            memoize ??= new Dictionary<int, bool>();
            if(memoize.ContainsKey(sum)) return memoize[sum];
            if (sum < 0) return false;
            if (sum == 0) return true;

            //for what i understand this goes through the array with "number", starts with current = false,
            //and then does current |= memize[sum]
            return array.Aggregate(false, (current, number) => current | (memoize[sum] = Memoize(sum - number, array, memoize)));
        }
        
        public static bool Tabulation(int sum, int[] array) {
            bool[] table = new bool[sum + 1];
            table[0] = true;
            for (int i = 0; i < sum; i++) {
                if (table[i] != true) continue;
                foreach (var number in array) {
                    if(i + number >= table.Length) continue;
                    table[i + number] = true;
                }
            }

            return table[sum];
        }
    }
}