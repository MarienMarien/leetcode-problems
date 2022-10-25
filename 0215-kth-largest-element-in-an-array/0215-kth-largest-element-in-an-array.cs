public class Solution {
    public int FindKthLargest(int[] nums, int k) {
         var pq = new PriorityQueue<int, int>();
        foreach (var n in nums) {
            pq.Enqueue(n, n);
            if (pq.Count > k)
                pq.Dequeue();
        }
        return pq.Peek();
    }
}