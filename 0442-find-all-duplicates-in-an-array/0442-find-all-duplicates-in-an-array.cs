public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        var res = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var absN = Math.Abs(nums[i]);
            var connectedId = absN == nums.Length ? 0 : absN;
            if (nums[connectedId] < 0)
            {
                res.Add(absN);
                continue;
            }
            nums[connectedId] = -nums[connectedId];
        }

        return res;
    }
}