using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1 {
    public class CanConstruct {
        /// <summary>
        /// returns whether is possible to construct the target string using elemnts in the array
        /// </summary>
        public static bool Memoize(string target, string[] array, Dictionary<string, bool> memoize = null) {
            memoize ??= new Dictionary<string, bool>();
            if (memoize.ContainsKey(target)) return memoize[target];
            if (target.Length == 0) return true;
            foreach (var word in array) {
                var targetBuffer = target;
                string shortenedTarget = target;
                bool removedEveryChar = true;
                StringBuilder sb = new StringBuilder(shortenedTarget);
                if(word.Length > target.Length) continue;
                var timesRemoved = 0;
                for (int i = 0; i < word.Length; i++) {
                    //all of this could've been solved easily with target.IndexOf(word) == 0;
                    //and shortenedTarget = target.Substring(word.Length);
                    //i used the correct way in CounConstruct.cs
                    if (word[i] != target[i]) {
                        removedEveryChar = false;
                        break;
                    }
                    sb.Remove(i - timesRemoved, 1);
                    timesRemoved++;
                }
                if(!removedEveryChar) continue;
                shortenedTarget = sb.ToString();
                var answer = Memoize(shortenedTarget, array, memoize);
                if (!answer) continue;
                memoize[target] = answer;
                return answer;
            }

            memoize[target] = false;
            return false;
        }

        public static bool Tabulation(string target, string[] array) {
            bool[] table = new bool[target.Length + 1];
            table[0] = true;
            for (int i = 0; i < target.Length; i++) {
                if (!table[i]) continue;
                foreach (var word in array) {
                    if (i + word.Length > target.Length) continue;
                    if (target.Substring(i, word.Length) != word) continue;
                    table[i + word.Length] = true;
                }
            }

            return table[target.Length];
        }
    }
}