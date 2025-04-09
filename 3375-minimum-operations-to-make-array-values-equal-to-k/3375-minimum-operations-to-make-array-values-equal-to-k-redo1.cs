public class Solution {
    public int MinOperations(int[] nums, int k) {
        Array.Sort(nums);
        if(nums[0] < k)
            return -1;
        if(nums[^1] == k)
            return 0;
        var opCount = 0;
        var id = nums.Length - 1;
        var prev = 0;
        while(id >= 0 && nums[id] > k)
        {
            opCount++;
            prev = nums[id];
            while(id >= 0 && nums[id] == prev)
                id--;
        }
        return opCount;   
    }
}