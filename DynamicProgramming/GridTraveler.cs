using System.Collections.Generic;

namespace TestProject1 {
    public class GridTraveler {
        /// <summary>
        /// how many ways to travel a grid of n by m, from top left to bottom right, only moving right or down
        /// </summary>
        /// <returns>how many ways there are</returns>
        public static long Travel(int rows, int columns, Dictionary<string, long> memoize = null) {
            /*is solved by reducing the grid by 1 row or column depending the move, base cases:
             0 rows or col, 0 moves.
             1 row and 1 col, 1 move.*/
            memoize ??= new Dictionary<string, long>();
            var key = rows + "*" + columns;
            if (memoize.ContainsKey(key)) return memoize[key];
            if (rows == 0 || columns == 0) return 0;
            if (rows == 1 && columns == 1) return 1;

            memoize[key] = Travel(rows - 1, columns, memoize) + Travel(rows, columns - 1, memoize);
            return memoize[key];
        }
    }
}