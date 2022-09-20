public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        var height = box.Length;
        var width = box[0].Length;
        var newBox = new char[width][];
        for (var row = 0; row < height; row++) {
            var lastEmptySpot = -1;
            var newRow = height - 1 - row;
            for (var col = width - 1; col >= 0; col--) {
                if(newBox[col] == null)
                    newBox[col] = new char[height];
                if (box[row][col] == '#' && lastEmptySpot >= 0)
                {
                    newBox[col][newRow] = '.';
                    newBox[lastEmptySpot][newRow] = '#';
                    lastEmptySpot--;
                    continue;
                }
                if (box[row][col] == '.' && lastEmptySpot < 0) {
                    lastEmptySpot = col;
                }
                if (box[row][col] == '*') {
                    lastEmptySpot = -1;
                }
                newBox[col][newRow] = box[row][col];
            }
        }
        return newBox;
    }
}