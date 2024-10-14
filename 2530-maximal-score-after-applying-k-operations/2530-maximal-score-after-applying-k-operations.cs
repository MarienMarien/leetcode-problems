public class Solution {
    public long MaxKelements(int[] nums, int k) {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        foreach(var n in nums)
            pq.Enqueue(n, n);
        
        long score = 0;
        while(pq.Count > 0 && k > 0)
        {
            var curr  =pq.Dequeue();
            score += curr;
            var newN = (int)Math.Ceiling(curr / 3.0);
            pq.Enqueue(newN, newN);
            k--;
        }

        return score;
    }
}