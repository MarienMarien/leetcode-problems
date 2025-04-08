public class Solution {
    public int Search(int[] nums, int target) {
        var start = 0; 
        var end = nums.Length - 1;
        var targetId = -1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(nums[mid] == target)
            {
                targetId = mid;
                break;
            }

            if(nums[mid] > target)
            {
                if(target <= nums[end] && IsRotated(nums, mid, end))
                    start = mid + 1;
                else
                    end = mid - 1;
            } 
            else 
            {
                if(target >= nums[start] && IsRotated(nums, start, mid))
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            
        }

        return targetId;
    }

    private bool IsRotated(int[] nums, int left, int right)
    {
        return nums[left] > nums[right];
    }
}