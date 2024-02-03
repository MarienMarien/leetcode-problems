public class Solution {
    public int[][] DivideArray(int[] nums, int k) {
        Array.Sort(nums);

        var id = 0;
        var ans = new int[nums.Length / 3][];
        var ansId = 0;
        while(id < nums.Length)
        {
            if(nums[id + 2] - nums[id] > k)
                return Array.Empty<int[]>();
            ans[ansId] = nums[id..(id + 3)];
            ansId++;
            id += 3;
        }

        return ans;
    }
}