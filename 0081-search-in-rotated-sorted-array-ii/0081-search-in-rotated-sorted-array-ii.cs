public class Solution {
    public bool Search(int[] nums, int target) {
        int start = 0;
        int end = nums.Length - 1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if (nums[mid] == target) {
                return true;
            }
            if(nums[start] == nums[mid]){
                start++;
                continue;
            }
            if (nums[start] < nums[mid])
            {
                if (nums[start] <= target && target < nums[mid])
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            else 
            {
                if (nums[mid] < target && target <= nums[end])
                    start = mid + 1;
                else
                    end = mid - 1;
            }
        }

        return false;
    }
}