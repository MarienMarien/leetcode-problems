public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        IList<IList<int>> ans = new List<IList<int>>();
        ans.Add(new List<int>());
        ans.Add(new List<int>());
        var map = new Dictionary<int, int>();
        foreach (var n in nums1) {
            map.TryAdd(n, 0);
        }
        foreach (var n in nums2) {
            if (!map.TryAdd(n, 1) && map[n] == 0)
                map[n] = 2;
        }
        foreach (var item in map) {
            if (item.Value < 2)
            {
                ans[item.Value].Add(item.Key);
            }
        }

        return ans;
    }
}