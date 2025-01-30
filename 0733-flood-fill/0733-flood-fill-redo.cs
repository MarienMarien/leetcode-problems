public class Solution {
    private int[][] _directions = {[0, 1], [1, 0], [0, -1], [-1, 0]};
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        if(color != image[sr][sc])
            Fill(image, sr, sc, color, image[sr][sc]);
        return image;
    }

    private void Fill(int[][] image, int row, int col, int color, int targetColor)
    {
        if(row < 0 || row >= image.Length || col < 0 || col >= image[0].Length || image[row][col] != targetColor)
            return;
        image[row][col] = color;
        foreach(var d in _directions)
        {
            Fill(image, row + d[0], col + d[1], color, targetColor);
        }
    }
}