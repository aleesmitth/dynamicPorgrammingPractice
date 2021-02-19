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
    }
}