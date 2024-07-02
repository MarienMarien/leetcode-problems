public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if (nums1.Length > nums2.Length)
            return Intersect(nums2, nums1);

        var map = new Dictionary<int, int>();

        foreach (var n in nums1) {
            if (!map.TryAdd(n, 1))
                map[n]++;
        }

        var res = new List<int>();

        foreach (var n in nums2)
        {
            if (map.ContainsKey(n))
            {
                res.Add(n);
                map[n]--;

                if (map[n] == 0)
                {
                    map.Remove(n);
                }
            }
        }

        return res.ToArray();
    }
}