public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        IList<string> res = new List<string>();
        var id = 0;
        while (id < nums.Length && nums[id] < lower)
            id++;
        var leftVal = lower;
        while (id < nums.Length && nums[id] <= upper) {
            if (leftVal == nums[id])
            {
                leftVal++;
                id++;
                continue;
            }
            var rightVal = nums[id] - 1;
            if (rightVal != leftVal)
            {
                res.Add($"{leftVal}->{rightVal}");
            }
            else {
                res.Add($"{leftVal}");
            }
            leftVal = nums[id] + 1;
            id++;
        }
        if (nums.Length == 0 || upper > nums[^1]) {
            var leftPart = leftVal != upper ? $"{leftVal}->": "";
            res.Add($"{leftPart}{upper}");
        }
        return res;
    }
}