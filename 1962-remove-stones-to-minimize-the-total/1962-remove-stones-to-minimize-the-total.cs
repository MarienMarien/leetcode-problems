public class Solution {
    public int MinStoneSum(int[] piles, int k) {
        var sum = 0;
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => { return y - x; }));
        foreach(var p in piles){
            sum += p;
            pq.Enqueue(p, p);
        }
        while(k > 0) {
            var curr = pq.Dequeue();
            sum -= curr;
            curr -= curr / 2;
            sum += curr;
            pq.Enqueue(curr, curr);
            k--;
        }
        
        return sum;
    }
}