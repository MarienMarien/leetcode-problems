public class Solution {
    public int LongestSquareStreak(int[] nums) {
        Array.Sort(nums);
        var squares = new Dictionary<long, int>();
        var longestStreak = -1;
        for (var i = 0; i < nums.Length; i++)
        {
            var sq = nums[i] * nums[i];
            var currSeqLen = 1;
            if (squares.ContainsKey(nums[i]))
                currSeqLen += squares[nums[i]];
            squares.TryAdd(sq, currSeqLen);
            if (currSeqLen > 1)
                longestStreak = Math.Max(longestStreak, currSeqLen);
        }

        return longestStreak;
    }
}