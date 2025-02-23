public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var maxOnesLen = 0;
        var prevOnesCount = 0;
        var currOnesCount = 0;
        var hasZero = false;

        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 1)
            {
                currOnesCount++;
            }
            maxOnesLen = Math.Max(maxOnesLen, prevOnesCount + currOnesCount);
            if(nums[i] == 0)
            {
                prevOnesCount = currOnesCount;
                currOnesCount = 0;
                hasZero = true;
            }
        }
        if(hasZero)
            maxOnesLen++;

        return maxOnesLen;
    }
}