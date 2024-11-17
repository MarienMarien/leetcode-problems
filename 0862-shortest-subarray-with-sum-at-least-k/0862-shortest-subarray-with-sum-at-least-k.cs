public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        var currSum = 0L;
        var shortestLen = Int32.MaxValue;
        var pq = new PriorityQueue<(long sum, int id), long>();
        for (var i = 0; i < nums.Length; i++)
        { 
            currSum += nums[i];
            if (currSum >= k)
            {
                shortestLen = Math.Min(shortestLen, i + 1);
            }

            while (pq.Count > 0 && currSum - pq.Peek().sum >= k)
            {
                var curr = pq.Dequeue();
                shortestLen = Math.Min(shortestLen, i - curr.id);
            }

            pq.Enqueue((currSum, i), currSum);
        }


        return shortestLen == Int32.MaxValue ? -1 : shortestLen;
    }
}