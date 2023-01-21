public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var res = 0;
        var map = new Dictionary<int, int>();
        map.Add(0,1);
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (map.ContainsKey(sum - k))
                res += map[sum - k];
            if (!map.TryAdd(sum, 1))
                    map[sum]++;
        }
        return res;
    }
}