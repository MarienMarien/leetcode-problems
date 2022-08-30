public class Solution {
    public int[] SmallerNumbersThanCurrent(int[] nums) {
        var res = new int[nums.Length];
        var numsCopy = new int[nums.Length];
        Array.Copy(nums, numsCopy, nums.Length);
        Array.Sort(numsCopy);
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < numsCopy.Length; i++) {
            if (i == 0) {
                dict.Add(numsCopy[i], 0);
                continue;
            }
            if (numsCopy[i] != numsCopy[i - 1])
            {
                dict.Add(numsCopy[i], i);
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            res[i] = dict[nums[i]];
        }
        return res;
    }
}