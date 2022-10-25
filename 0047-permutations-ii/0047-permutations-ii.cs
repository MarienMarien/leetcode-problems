public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> res = new List<IList<int>>();
        Backtrack2(0, nums, res);

        return res;
    }

    private static void Backtrack2(int start, int[] nums, IList<IList<int>> res)
    {
        if (start == nums.Length) {
            res.Add(new List<int>(nums));
            return;
        }

        var lookup = new HashSet<int>();
        for (var i = start; i < nums.Length; i++) {
            if (!lookup.Contains(nums[i])) {
                Swap(nums, start, i);
                Backtrack2(start + 1, nums, res);
                Swap(nums, start, i);
                lookup.Add(nums[i]);
            }
        }
    }

    private static void Swap(int[] nums, int start, int i)
    {
        var tmp = nums[start];
        nums[start] = nums[i];
        nums[i] = tmp;
    }
}