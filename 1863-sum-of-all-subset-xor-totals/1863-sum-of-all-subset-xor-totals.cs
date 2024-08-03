public class Solution {
    private int _sum;

    public int SubsetXORSum(int[] nums) {
        CountSum(nums, 0, 0);
        return _sum;    
    }

    private void CountSum(int[] nums, int currentXor, int startFrom)
    {
        if(startFrom >= nums.Length)
            return;
        for(var i = startFrom; i < nums.Length; i++)
        {
            currentXor = currentXor ^ nums[i];
            _sum += currentXor;
            CountSum(nums, currentXor, i + 1);
            currentXor = currentXor ^ nums[i];
        }
    }
}