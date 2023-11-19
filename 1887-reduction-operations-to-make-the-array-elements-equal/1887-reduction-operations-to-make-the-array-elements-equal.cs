public class Solution {
    public int ReductionOperations(int[] nums) {
        Array.Sort(nums);
        var prev = nums[0];
        var opToSmallest = 0;
        var totalOp = 0;
        foreach (var n in  nums) {
            if (n != prev) {
                opToSmallest++;
                prev = n;
            }
            totalOp += opToSmallest;
        }
        return totalOp;
    }
}