public class Solution {
    public int[] FindErrorNums(int[] nums) {
        Array.Sort(nums);
        var duplicate = 0;
        var missed = nums[nums.Length - 1] != nums.Length ? nums.Length : 1;
        for(var i = 1; i < nums.Length; i++){
            if(nums[i] == nums[i - 1]){
                duplicate = nums[i];
            } else if(nums[i] > nums[i - 1] + 1){
                missed = nums[i - 1] + 1;
            }
        }
        return new int[2] { duplicate, missed };
    }
}