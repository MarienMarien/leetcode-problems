public class Solution {
    public long CountSubarrays(int[] nums) {
        long count = 1;
        var subarrayEndId = nums.Length - 1;

        for (var i = nums.Length - 2; i >= 0; i--) {
            if (nums[i + 1] > nums[i])
            {
                count += subarrayEndId - i + 1;
            }
            else {
                subarrayEndId = i;
                count++;
            }
        }

        return count;
    }
}