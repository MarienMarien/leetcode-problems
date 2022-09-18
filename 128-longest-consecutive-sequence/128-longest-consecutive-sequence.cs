public class Solution {
    public int LongestConsecutive(int[] nums) {
        var numsSet = new HashSet<int>();
        for (var i = 0; i < nums.Length; i++) {
            if (!numsSet.Contains(nums[i]))
                numsSet.Add(nums[i]);
        }
        var maxSequence = 0;
        foreach (var n in numsSet) {
            if (!numsSet.Contains(n - 1)) {
                var currN = n;
                var currSequence = 1;
                while (numsSet.Contains(currN + 1)) {
                    currN++;
                    currSequence++;
                }
                maxSequence = Math.Max(maxSequence, currSequence);
            }
        }
        return maxSequence;
    }
}