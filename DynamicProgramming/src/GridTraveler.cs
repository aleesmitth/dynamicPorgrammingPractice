using System.Collections.Generic;

namespace TestProject1 {
    public class GridTraveler {
        /// <summary>
        /// how many ways to travel a grid of n by m, from top left to bottom right, only moving right or down
        /// </summary>
        /// <returns>how many ways there are</returns>
        public static long Memoize(int rows, int columns, Dictionary<string, long> memoize = null) {
            /*is solved by reducing the grid by 1 row or column depending the move, base cases:
             0 rows or col, 0 moves.
             1 row and 1 col, 1 move.*/
            memoize ??= new Dictionary<string, long>();
            var key = rows + "*" + columns;
            if (memoize.ContainsKey(key)) return memoize[key];
            if (rows == 0 || columns == 0) return 0;
            if (rows == 1 && columns == 1) return 1;

            memoize[key] = Memoize(rows - 1, columns, memoize) + Memoize(rows, columns - 1, memoize);
            return memoize[key];
        }
        
        /// <summary>
        /// how many ways there are to travel a grid of n by m, from top left to bottom right, only moving right or down
        /// </summary>
        /// <returns>how many ways there are</returns>
        public static long Tabulation(int rows, int columns) {
            //if i dont do +2 then from row=1, col=1 it only updates 0,0. 0,1. 1,0. not 1,1.
            long[][] table = new long[rows + 2][];
            for (int i = 0; i <= rows + 1; i++) {
                table[i] = new long[columns + 2];
            }

            table[0][0] = 0;
            table[1][1] = 1;

            for (int i = 0; i <= rows; i++) {
                for (int j = 0; j <= columns; j++) {
                    table[i + 1][j] += table[i][j];
                    table[i][j + 1] += table[i][j];
                }
            }

            return table[rows][columns];
        }
    }
}