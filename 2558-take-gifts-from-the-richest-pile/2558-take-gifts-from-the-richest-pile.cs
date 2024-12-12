public class Solution {
    public long PickGifts(int[] gifts, int k) {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y)=> y - x));
        foreach(var g in gifts)
            pq.Enqueue(g, g);
        while(k > 0)
        {
            var pile = pq.Dequeue();
            var sqPile = (int)Math.Sqrt(pile);
            pq.Enqueue(sqPile, sqPile);
            k--;
        }
        var remGifts = 0L;
        while(pq.Count > 0)
            remGifts += pq.Dequeue();
        return remGifts;
    }
}