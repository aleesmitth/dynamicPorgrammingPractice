using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1 {
    public class CountConstruct {
        /// <summary>
        /// returns the number of possible ways to construct the target string using the elements in the array.
        /// </summary>
        public static int Memoize(string target, string[] array, Dictionary<string,int> memoize = null) {
            memoize ??= new Dictionary<string, int>();
            if (memoize.ContainsKey(target)) return memoize[target];
            if (target.Length == 0) return 1;
            if (!memoize.ContainsKey(target)) memoize[target] = 0;
            foreach (var word in array) {
                if (target.IndexOf(word, StringComparison.Ordinal) != 0) continue;
                var shortenedTarget = target.Substring(word.Length);
                memoize[target] += Memoize(shortenedTarget, array, memoize);
            }
            return memoize[target];
        }
        
        public static int Tabulation(string target, string[] array) {
            int[] table = new int[target.Length + 1];
            table[0] = 1;
            for (int i = 0; i < target.Length; i++) {
                if(table[i] == 0) continue;
                foreach (var word in array) {
                    if(word.Length + i > target.Length) continue;
                    if (target.Substring(i, word.Length) != word) continue;
                    table[word.Length + i] += table[i];
                }
            }

            return table[target.Length];
        }
    }
}