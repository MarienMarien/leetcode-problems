public class Solution {
    public int MinimumAverageDifference(int[] nums) {
        var minAvgId = 0;
            if (nums.Length == 1)
                return minAvgId;
            var numsCount = nums.Length;
            long rightSum = 0;
            long leftSum = 0;
            long minAvgSum = Int32.MaxValue;
            long totalSum = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                totalSum += nums[i];
            }
            
            for (var i = 0; i < nums.Length; i++)
            {
                leftSum += nums[i];
                rightSum = totalSum - leftSum;
                var leftAvg = leftSum / (i + 1);
                var rightAvg = i != nums.Length - 1 ? rightSum / (numsCount - i - 1) : 0;
                long currAvgSum = Math.Abs(leftAvg - rightAvg);
                if (minAvgSum > currAvgSum)
                {
                    minAvgSum = currAvgSum;
                    minAvgId = i;
                }

            }

            return minAvgId;
    }
}