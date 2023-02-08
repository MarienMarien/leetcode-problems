public class Solution {
    public void WiggleSort(int[] nums) {
        for (var i = 0; i < nums.Length; i++) {
            if ((i % 2 == 0 && (i + 1 < nums.Length && nums[i] > nums[i+1])) 
                || (i % 2 != 0 && (i + 1 < nums.Length && nums[i] < nums[i + 1]))) {
                var tmp = nums[i];
                nums[i] = nums[i + 1];
                nums[i + 1] = tmp;
            }
        }
    }
}