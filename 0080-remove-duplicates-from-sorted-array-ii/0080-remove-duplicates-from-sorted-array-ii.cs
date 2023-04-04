public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var k = 0;
        var curr = nums[0];
        var currCount = 0;
        for (var i = 0; i < nums.Length; i++) {
            if (nums[i] != curr)
            {
                curr = nums[i];
                currCount = 1;
            }
            else {
                currCount++;
                if (currCount > 2)
                {
                    k++;
                    continue;
                }
            }
            nums[i - k] = nums[i];
        }
        return nums.Length - k;
    }
}