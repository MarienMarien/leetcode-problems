public class Solution {
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        var res = new int[rows * cols][];
        var resId = 0;
        res[resId] = new int[] { rStart, cStart };
        resId++;

        var swirlLen = 1;
        var directionKoef = 1;

        var currCol = cStart;
        var currRow = rStart;

        while (resId < rows * cols){
            for (var c = 0; c < swirlLen; c++)
            {
                currCol += 1 * directionKoef;
                if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < cols) {
                    res[resId] = new int[] { currRow, currCol };
                    resId++;
                }
            }

            for (var r = 0; r < swirlLen; r++)
            {
                currRow += 1 * directionKoef;
                if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < cols)
                {
                    res[resId] = new int[] { currRow, currCol };
                    resId++;
                }
            }

            swirlLen++;
            directionKoef *= -1;
        }

        return res;
    }
}