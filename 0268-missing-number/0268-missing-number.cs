public class Solution {
    public int MissingNumber(int[] nums) {
         var len = nums.Length;
        var neededSum = (len * (len + 1)) / 2;
        var sum = 0;
        foreach (var n in nums) {
            sum += n;
        }
        return neededSum - sum;
    }
}