public class Solution {
    public int ThreeSumSmaller(int[] nums, int target) {
        if(nums.Length < 3)
            return 0;
        Array.Sort(nums);
        var count = 0;
        for(var i = 0; i < nums.Length - 2; i++) {
            var checkSum = target - nums[i];
            var start = i + 1; 
            var end = nums.Length - 1;
            while(start < end){
                var currSum = nums[start] + nums[end];
                if(currSum < checkSum){
                    count += end - start;
                    start++;
                } else {
                    end--;
                }

            }
        }
        return count;
    }
}