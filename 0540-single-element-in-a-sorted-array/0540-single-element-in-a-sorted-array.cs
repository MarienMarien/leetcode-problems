public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        var start = 0;
        var end = nums.Length - 1;
        while(start < end){
            var mid = (end + start) / 2;
            if(mid % 2 == 1)
                mid--;
            if(nums[mid] == nums[mid + 1]){
                start = mid + 2;
            } else {
                end = mid;
            }
        }
        return nums[start];
    }
}