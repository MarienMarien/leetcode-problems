public class Solution {
    public int FindPairs(int[] nums, int k)
    {
        var countDiffPairs = 0;
        if (nums.Length == 1)
            return countDiffPairs;
        Array.Sort(nums);

        var left = 0;
        var right = 1;
        var seen = new Dictionary<int, int>();

        while (right < nums.Length)
        {
            if (left == right || (seen.ContainsKey(nums[left]) && seen[nums[left]] == nums[right]))
            { 
                right++;
                continue;
            }

            var diff = nums[right] - nums[left];
            if (diff == k)
            {
                countDiffPairs++;
                seen.Add(nums[left], nums[right]);
            }
            if (diff <= k)
                right++;
            if (diff >= k)
                left++;
        }

        return countDiffPairs;
    }
}