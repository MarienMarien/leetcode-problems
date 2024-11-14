public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        if(n == 1)
            return quantities[0];
        var pq = new PriorityQueue<(int q, int stores), (int q, int stores)>
            (Comparer<(int q, int stores)>.Create((x, y) => {
                var xPriority = x.q * y.stores;
                var yPriority = y.q * x.stores;
                if (xPriority == yPriority)
                    return y.q - x.q;
                return yPriority - xPriority;
        }));

        foreach (var q in quantities)
        {
            pq.Enqueue((q, 1), (q, 1));
        }

        var storesRem = n - quantities.Length;
        for(var i = 0; i < storesRem; i++)
        {
            var curr = pq.Dequeue();
            curr.stores++;
            pq.Enqueue(curr, curr);
        }

        var largest = pq.Peek();
        return (int)Math.Ceiling((double)largest.q / largest.stores);
    }
}