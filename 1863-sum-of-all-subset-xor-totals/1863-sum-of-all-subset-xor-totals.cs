public class Solution {
    public int SubsetXORSum(int[] nums) {
        return GetXorSum(nums, 0, 0, 0);
    }

    private int GetXorSum(int[] nums, int sum, int currXor, int startId)
    {
        for(var i = startId; i < nums.Length; i++)
        {
            currXor ^= nums[i];
            sum = currXor + GetXorSum(nums, sum, currXor, i + 1);
            currXor ^= nums[i];
        }

        return sum;
    }
}