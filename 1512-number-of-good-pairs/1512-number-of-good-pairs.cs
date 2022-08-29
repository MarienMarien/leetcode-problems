public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        var set = new Dictionary<int, int>();
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (!set.ContainsKey(nums[i]))
                set.Add(nums[i], 0);
            else
            {
                set[nums[i]]++;
                count += set[nums[i]];
            }
        }

        return count;
    }
}