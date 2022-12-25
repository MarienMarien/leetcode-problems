public class Solution {
    public int Search(int[] nums, int target) {
        var start = 0; 
        var end = nums.Length - 1;
        while(start <= end){
            var mid = start + (end - start) / 2;
            if(nums[mid] == target)
                return mid;
            if(nums[mid] < target)
                start = mid + 1;
            else
                end = mid - 1;
        }
        return nums[0] == target ? 0 : -1;
    }
}