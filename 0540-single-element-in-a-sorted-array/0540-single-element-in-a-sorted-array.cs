public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        if (nums.Length % 2 == 0)
            return -1;
        var start = 0;
        var end = nums.Length - 1;
        while (start < end)
        {
            var mid = start + ((end - start) / 2);
            if (mid % 2 == 1)
                mid--;
            if (nums[mid] == nums[mid + 1])
                start += 2;
            else
                end = mid;
        }
        return nums[start];
    }
}