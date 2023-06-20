public class Solution {
    public int[] GetAverages(int[] nums, int k) {
        if (k == 0)
            return nums;
        var len = nums.Length;
        var windowStartPos = 0;
        long prefSum = 0;
        var result = new int[len];
        var positiveResultId = k;
        var windowWidth = k * 2;
        for (var i = 0; i < len; i++) {
            prefSum += nums[i];
            if (i < k || i >= len - k)
            {
                result[i] = -1;
            }
            if(i >= windowWidth)
            {
                result[positiveResultId] = (int)(prefSum / (windowWidth + 1));
                positiveResultId++;
                prefSum -= nums[windowStartPos++];
            }
            
        }
        return result;
    }
}