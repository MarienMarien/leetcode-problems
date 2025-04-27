public class Solution {
    private int _leftX;
    private int _rightX;
    private int _upY;
    private int _bottomY;
    private int[][] _directions = { [0, 1], [1, 0], [0, -1], [-1, 0] };
    public int MinArea(char[][] image, int x, int y) {
        _leftX = y;
        _rightX = y;
        _upY = x;
        _bottomY = x;
        TraverseIsland(image, x, y);
        var area = (_rightX - _leftX + 1) * (_bottomY - _upY + 1);
        return area;
    }

    private void TraverseIsland(char[][] image, int row, int col)
    {
        if(row < 0 || row >= image.Length || col < 0 || col >= image[0].Length || image[row][col] != '1')
            return;
        image[row][col] = '2';
        _leftX = Math.Min(_leftX, col);
        _rightX = Math.Max(_rightX, col);
        _upY = Math.Min(_upY, row);
        _bottomY = Math.Max(_bottomY, row);
        foreach(var d in _directions)
        {
            TraverseIsland(image, row + d[0], col + d[1]);
        }
    }
}