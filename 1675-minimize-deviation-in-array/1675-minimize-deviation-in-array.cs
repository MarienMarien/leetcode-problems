public class Solution {
    public int MinimumDeviation(int[] nums) {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a,b) => b - a));
        var min = Int32.MaxValue;
        foreach (var n in nums) {
            var element = n;
            if (n % 2 == 1)
                element *= 2;
            pq.Enqueue(element, element);
            if (element < min)
                min = element;
        }
        var minDev = Int32.MaxValue;
        while (pq.Count > 0) {
            var element = pq.Dequeue();
            minDev = Math.Min(minDev, element - min);
            if (element % 2 == 0)
            {
                element /= 2;
                min = Math.Min(min, element);
                pq.Enqueue(element, element);
            }
            else
                break;
        }
        return minDev;
    }
}