using System.Collections.Generic;

namespace TestProject1 {
    public class Fibonacci {
        /// <summary>
        /// returns the nth fibonacci number using memoize approach
        /// </summary>
        public static long Memoize(int n, Dictionary<int, long> memoize = null){
            memoize ??= new Dictionary<int, long>();
            if (memoize.ContainsKey(n)) return memoize[n];
            if (n == 0) return 0;
            if (n == 1) return 1;
            
            memoize[n] = Memoize(n - 1, memoize) + Memoize(n - 2, memoize);
            return memoize[n];
        }
        
        /// <summary>
        /// returns the nth fibonacci number using bottom up approach, better space complexity than memoize 
        /// </summary>
        public static long BottomUp(int n) {
            //adding 2 in case n is 0
            long[] buffer = new long[n + 2];
            buffer[0] = 0;
            buffer[1] = 1;
            for (int i = 2; i <= n; i++) {
                buffer[i] = buffer[i - 2] + buffer[i - 1];
            }

            return buffer[n];
        }
    }
}