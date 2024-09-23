public class Solution {
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        var pq = new PriorityQueue<(int workTime, long nextTime, long takenTime), (int, long, long)>(Comparer<(int workTime, long nextTime, long takenTime)>.Create((x,y) => {

            var sumX = x.workTime + x.nextTime + x.takenTime;
            var sumY = y.workTime + y.nextTime + y.takenTime;
            if (sumX == sumY)
                return x.workTime > y.workTime ? 1 : -1;
            return sumX.CompareTo(sumY);
        }));

        foreach (var wt in workerTimes)
        {
            var item = (wt, 0, 0);
            pq.Enqueue(item, item);
        }

        for (var work = 0; work < mountainHeight; work++)
        {
            var curr = pq.Dequeue();
            curr.takenTime += curr.nextTime + curr.workTime;
            curr.nextTime += curr.workTime;
            pq.Enqueue(curr, curr);
        }

        var minSec = 0L;
        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            minSec = Math.Max(minSec, curr.takenTime);
        }

        return minSec;
    }
}