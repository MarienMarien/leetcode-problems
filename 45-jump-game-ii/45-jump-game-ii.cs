public class Solution {
    public int Jump(int[] nums) {
         int jumps = 0, currentJumpEnd = 0, farthest = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (i == currentJumpEnd)
            {
                jumps++;
                currentJumpEnd = farthest;
            }
        }
        return jumps;
    }
}