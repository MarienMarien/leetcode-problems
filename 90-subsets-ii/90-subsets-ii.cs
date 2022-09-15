public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> res = new List<IList<int>>();
        GenerateSubsets(nums, new List<int>(), res, 0);
        return res;
    }

    private void GenerateSubsets(int[] nums, List<int> list, IList<IList<int>> res, int start)
    {
        res.Add(new List<int>(list));
        var deleted = -20; // -10 <= nums[i] <= 10
        for (var i = start; i < nums.Length; i++) {
            if (nums[i] == deleted)
                continue;
            list.Add(nums[i]);
            GenerateSubsets(nums, list, res, i + 1);
            list.RemoveAt(list.Count - 1);
            deleted = nums[i];
        }
    }
}