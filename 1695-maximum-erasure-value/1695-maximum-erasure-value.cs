public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        var prefSum = new int[nums.Length];
        prefSum[0] = nums[0];
        for(var i = 1; i < nums.Length; i++)
        {
            prefSum[i] = prefSum[i - 1] + nums[i];
        }
        var idsMap = new Dictionary<int, int>();
        var maxSum = nums[0];
        var windowStart = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            var currNum = nums[i];
            if(!idsMap.ContainsKey(currNum))
            {
                idsMap.Add(currNum, i);
            }
            else {
                windowStart = Math.Max(windowStart, idsMap[currNum] + 1);
                idsMap[currNum] = i;
            }

            var currSum = prefSum[i];
            if(windowStart > 0)
            {
                currSum -= prefSum[windowStart - 1];
            }
            maxSum = Math.Max(maxSum, currSum);
        }
        
        return maxSum;
    }
}