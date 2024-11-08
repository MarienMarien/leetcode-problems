public class Solution {
    public int[] GetMaximumXor(int[] nums, int maximumBit) {
        var ans = new int[nums.Length];
        var maxK = (1 << maximumBit) - 1;
        var ansId = nums.Length - 1;
        ans[ansId--] = nums[0] ^ maxK;

        for (var i = 1; i < ans.Length; i++)
        {
            ans[ansId] = ans[ansId + 1] ^ nums[i];
            ansId--;
        }

        return ans;
    }
}