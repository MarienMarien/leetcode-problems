public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
         var chosedColor = image[sr][sc];
        if (chosedColor == newColor)
            return image;
        ChangeColor(image, sr, sc, chosedColor, newColor);
        return image;
    }

    private void ChangeColor(int[][] image, int sr, int sc, int chosedColor, int newColor)
    {
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] != chosedColor)
            return;
        image[sr][sc] = newColor;
        ChangeColor(image, sr - 1, sc, chosedColor, newColor);
        ChangeColor(image, sr, sc + 1, chosedColor, newColor);
        ChangeColor(image, sr + 1, sc, chosedColor, newColor);
        ChangeColor(image, sr, sc - 1, chosedColor, newColor);
    }
}