/**
 * // This is BinaryMatrix's API interface.
 * // You should not implement it, or speculate about its implementation
 * class BinaryMatrix {
 *     public int Get(int row, int col) {}
 *     public IList<int> Dimensions() {}
 * }
 */

class Solution {
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) {
        var dimensions = binaryMatrix.Dimensions();
        var rowsCount = dimensions[0];
        var colsCount = dimensions[1];
        var start = 0;
        var end = colsCount - 1;
        while (start <= end) {
            var midCol = start + (end - start) / 2;
            var currCol = midCol;
            var leftmostOne = -1;
            for(var row = 0; row < rowsCount; row++){
                while(currCol >= 0 && binaryMatrix.Get(row, currCol) == 1) {
                    leftmostOne = currCol;
                    currCol--;
                }
            }
            if(leftmostOne >= 0)
                return leftmostOne;
            start = midCol + 1;
        }
        return -1;
    }
}