public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        if (nums == null || nums.Length == 0 || k == 0)
                return false;
            var numSet = new HashSet<int>();
            for (var i = 0; i < nums.Length; i++) {
                if (numSet.Contains(nums[i])) {
                    return true;
                }
                numSet.Add(nums[i]);
                if(i >= k)
                {
                    numSet.Remove(nums[i - k]);
                }
            }
            return false;
    }
}