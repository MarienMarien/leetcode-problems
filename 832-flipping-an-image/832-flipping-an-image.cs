public class Solution {
    public int[][] FlipAndInvertImage(int[][] image) {
        var colsLen = image[0].Length;
        for (var row = 0; row < image.Length; row++) {
            var start = 0; var end = colsLen - 1;
            while (start <= end) {
                if (start == end)
                {
                    image[row][start] = image[row][start] ^ 1;
                }
                else{
                    var left = image[row][start];
                    var right = image[row][end];
                    image[row][start] = right ^ 1;
                    image[row][end] = left ^ 1;
                }
                start++;
                end--;
            }
        }
        return image;
    }
}