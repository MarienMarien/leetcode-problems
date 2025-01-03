public class Solution {
    public int WaysToSplitArray(int[] nums) {
        var rightSum = 0L;
        foreach(var n in nums)
        {
            rightSum += n;
        }

        var leftSum = 0L;
        var splitsCount = 0;
        for(var i = 0; i < nums.Length - 1; i++)
        {
            leftSum += nums[i];
            rightSum -= nums[i];
            if(leftSum >= rightSum)
                splitsCount++;
        }
        return splitsCount;
    }
}