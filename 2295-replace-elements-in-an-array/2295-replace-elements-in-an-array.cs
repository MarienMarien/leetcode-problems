public class Solution {
    public int[] ArrayChange(int[] nums, int[][] operations) {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            map.Add(nums[i], i);
        }
        foreach (var op in operations) {
            var id = map[op[0]];
            map.Remove(op[0]);
            map.Add(op[1], id);
        }
        foreach (var entry in map) {
            nums[entry.Value] = entry.Key;
        }
        return nums;
    }
}