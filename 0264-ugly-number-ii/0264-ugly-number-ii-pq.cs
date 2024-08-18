public class Solution {
    public int NthUglyNumber(int n) {
        var uglyNthNum = 1L;

        if (n == uglyNthNum)
            return (int)uglyNthNum;

        var factors = new HashSet<int>() { 2, 3, 5 };
        var pq = new PriorityQueue<long, long>();
        pq.Enqueue(1, 1);
        var uglyNumbers = new HashSet<long>();


        for (var i = 1; i <= n; i++)
        {
            uglyNthNum = pq.Dequeue();

            foreach (var f in factors)
            {
                var candidate = uglyNthNum * f;
                if (!uglyNumbers.Contains(candidate)) 
                {
                    pq.Enqueue(candidate, candidate);
                    uglyNumbers.Add(candidate);
                }
            }
        }

        return (int)uglyNthNum;
    }
}