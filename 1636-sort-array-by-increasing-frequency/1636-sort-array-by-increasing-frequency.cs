public class Solution {
    public int[] FrequencySort(int[] nums) {
        var map = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!map.TryAdd(n, 1))
                map[n]++;
        }

        Array.Sort(nums, Comparer<int>.Create((x, y) =>
            {
                if (map[x] == map[y])
                    return y - x;
                return map[x] - map[y];
            }));

        return nums;
    }
}