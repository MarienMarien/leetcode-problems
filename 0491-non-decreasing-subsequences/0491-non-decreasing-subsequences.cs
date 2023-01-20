public class Solution {
    private ISet<IList<int>> _result;
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        _result = new HashSet<IList<int>>();
        GenerateSubsequences(nums, 0, new List<int>());
        return _result.ToList();
    }

    private void GenerateSubsequences(int[] nums, int id, IList<int> list)
    {
        if (list.Count >= 2 && !_result.Contains(list))
            _result.Add(new List<int>(list));
        var used = new HashSet<int>();
        for (var i = id; i < nums.Length; i++)
        {
            if (used.Contains(nums[i]))
                continue;
            if (list.Count == 0 || list[list.Count - 1] <= nums[i])
            {
                used.Add(nums[i]);
                list.Add(nums[i]);
                GenerateSubsequences(nums, i + 1, list);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}