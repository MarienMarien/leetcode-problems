public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        if(nums.Length == 1)
            return nums[0];
        if (nums[0] != nums[1])
            return nums[0];
        if (nums[nums.Length - 1] != nums[nums.Length - 2])
            return nums[nums.Length - 1];
        // ???
        if (nums.Length % 2 == 0)
            return -1;
        var start = 0;
        var end = nums.Length - 1;
        while (start < end) {
            var mid = start + ((end - start) / 2);
            if ((end - start) > 1 && mid % 2 == 0)
                mid--;
            if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
                return nums[mid];
            if (nums[mid] == nums[mid + 1])
            {
                end = mid;
            }
            else {
                start = mid + 1;
            }
        }
        return -1;
    }
}