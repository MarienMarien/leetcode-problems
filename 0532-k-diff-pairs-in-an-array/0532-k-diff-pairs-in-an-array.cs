public class Solution {
    public int FindPairs(int[] nums, int k) {
        var set = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (!set.TryAdd(n, 1))
                set[n]++;
        }
        var count = 0;
        foreach (var it in set) {
            if (k > 0 && set.ContainsKey(it.Key + k))
                count++;
            else if (k == 0 && it.Value > 1)
                count++;
        }
        return count;
    }
}