public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var unique = new HashSet<int>();
            for (var i = 0; i < nums.Length; i++) {
                if (unique.Contains(nums[i]))
                    return true;
                else {
                    unique.Add(nums[i]);
                }
            }
            return false;
    }
}