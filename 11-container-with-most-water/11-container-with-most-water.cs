public class Solution {
    public int MaxArea(int[] height) {
        var maxWaterArea = 0;
        var start = 0;
        var end = height.Length - 1;
        while (start < end) {
            maxWaterArea = Math.Max(maxWaterArea, Math.Min(height[start], height[end]) * (end - start));
            if (height[end] >= height[start]) {
                start++;
            }
            else { 
                end--;
            }
        }
        return maxWaterArea;
    }
}