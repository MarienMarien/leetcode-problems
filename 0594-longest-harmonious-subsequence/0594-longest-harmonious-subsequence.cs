public class Solution {
    public int FindLHS(int[] nums) {
        Array.Sort(nums);
        var first = nums[0];
        var second = first;
        var countFirst = 1;
        var countSecond = 0;
        var maxLen = 0;
        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i] == first)
            {
                countFirst++;
                continue;
            }
            if(second == first)
                second = nums[i];
            if(nums[i] == second)
            {
                countSecond++;
                continue;
            }
            if(second - first == 1)
            {
                maxLen = Math.Max(maxLen, countFirst + countSecond);
            }
            first = second;
            countFirst = countSecond;
            second = nums[i];
            countSecond = 1;
        }
        if(second - first == 1)
        {
            maxLen = Math.Max(maxLen, countFirst + countSecond);
        }

        return maxLen;
    }
}