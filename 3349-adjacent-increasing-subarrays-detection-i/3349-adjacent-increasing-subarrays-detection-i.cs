public class Solution {
    public bool HasIncreasingSubarrays(IList<int> nums, int k) {
        if (k == 1)
            return true;
        var checkedCount = 1;
        for (int i = k + 1, pi = 1; i < nums.Count; i++, pi++)
        {
            if (nums[i] > nums[i - 1] && nums[pi] > nums[pi - 1])
            {
                checkedCount++;
            }
            else {
                checkedCount = 1;
            }

            if (checkedCount == k)
                return true;
        }
        return false;
    }
}