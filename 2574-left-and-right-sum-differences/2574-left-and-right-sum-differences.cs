public class Solution {
    public int[] LeftRigthDifference(int[] nums) {
        var answer = new int[nums.Length];
        for (var i = 1; i < nums.Length; i++) {
            answer[i] += answer[i - 1] + nums[i - 1];
        }
        var rightSum = 0;
        for (var i = nums.Length - 2; i >= 0; i--) {
            rightSum += nums[i + 1];
            answer[i] = Math.Abs(answer[i] - rightSum);
        }
        return answer;
    }
}