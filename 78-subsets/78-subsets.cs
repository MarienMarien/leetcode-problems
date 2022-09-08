public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        res.Add(new List<int>());
        GenerateSubsets(nums, res, new List<int>(), 0);
        return res;
    }

    private void GenerateSubsets(int[] nums, IList<IList<int>> res, List<int> list, int start)
    {
        for (var i = start; i < nums.Length; i++) { 
            list.Add(nums[i]);
            res.Add(new List<int>(list));
            GenerateSubsets(nums, res, list, i + 1);
            list.Remove(nums[i]);
        }
    }
}