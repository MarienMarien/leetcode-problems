public class Solution {
    public int SearchInsert(int[] nums, int target) {
        var start = 0;
        var end = nums.Length - 1;
        var id = 0;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(nums[mid] == target)
                return mid;
            if(nums[mid] > target)
            {
                end = mid - 1;
            } 
            else
            {
                start = mid + 1;
                id = start;
            }
        }

        return id;
    }
}