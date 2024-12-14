public class Solution {
    public long ContinuousSubarrays(int[] nums) {
        var minHeap = new PriorityQueue<int, int>();
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        var windowStartId = 0;
        var subArrCount = 0L;
        var windowEndId = 0;
        while(windowEndId < nums.Length)
        {
            minHeap.Enqueue(windowEndId, nums[windowEndId]);
            maxHeap.Enqueue(windowEndId, nums[windowEndId]);
            while (windowStartId < windowEndId && nums[maxHeap.Peek()] - nums[minHeap.Peek()] > 2)
            {
                windowStartId++;
                while (minHeap.Count > 0 && minHeap.Peek() < windowStartId)
                    minHeap.Dequeue();
                while (maxHeap.Count > 0 && maxHeap.Peek() < windowStartId)
                    maxHeap.Dequeue();
            }
            subArrCount += windowEndId - windowStartId + 1;
            windowEndId++;
        }

        return subArrCount;  
    }
}