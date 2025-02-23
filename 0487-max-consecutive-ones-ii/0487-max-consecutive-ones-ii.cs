public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var startCandidates = new Queue<int>();
        var start = 0;
        var maxOnesLen = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
            {
                if(startCandidates.Count > 0)
                {
                    maxOnesLen = Math.Max(maxOnesLen, i - start);
                    start = startCandidates.Dequeue();
                }
                startCandidates.Enqueue(i < nums.Length - 1 ? i + 1 : i);
            }
        }
        
        maxOnesLen = Math.Max(maxOnesLen, nums.Length - start);

        return maxOnesLen;
    }
}