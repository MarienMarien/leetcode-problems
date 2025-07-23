public class Solution {
    public int MaxArea(int[] height) {
        var left = 0;
        var right = height.Length - 1;
        var maxArea = 0;
        while(left < right)
        {
            var len = right - left;
            var side = Math.Min(height[left], height[right]);
            var currArea = len * side;
            maxArea = Math.Max(maxArea, currArea);
            if(height[left] < height[right])
            {
                left++;
            }
            else 
            {
                right--;
            }
        }

        return maxArea;
    }
}