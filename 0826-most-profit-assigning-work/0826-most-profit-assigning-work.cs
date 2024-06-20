public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        Array.Sort(worker);

        var pq = new PriorityQueue<(int prof, int diff), (int prof, int diff)>(Comparer<(int prof, int diff)>.Create((x, y) => 
        {
            if (x.prof == y.prof)
                return y.diff - x.diff;
            return y.prof - x.prof;
                
        }));

        for (var i = 0; i < difficulty.Length; i++) 
        {
            var item = (profit[i], difficulty[i]);
            pq.Enqueue(item, item);
        }

        var maxProfit = 0;
        var workerId = worker.Length - 1;

        var curr = pq.Dequeue();
        while (workerId >= 0)
        {
            if (curr.diff > worker[workerId])
            {
                if (pq.Count == 0)
                    break;

                curr = pq.Dequeue();
                continue;
            }

            maxProfit += curr.prof;
            workerId--;
        }

        return maxProfit;
    }
}