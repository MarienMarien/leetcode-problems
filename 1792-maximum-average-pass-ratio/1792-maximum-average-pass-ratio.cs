public class Solution {
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        var pq = new PriorityQueue<(int passed, int students), double>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
        foreach (var c in classes)
        {
            var gain = CalcGain(c[0], c[1]);
            pq.Enqueue((c[0], c[1]), gain);
        }

        while (extraStudents > 0)
        {
            var extra = pq.Dequeue();
            var gain = CalcGain(extra.passed + 1, extra.students + 1);
            pq.Enqueue((extra.passed + 1, extra.students + 1), gain);
            extraStudents--;
        }

        var maxAvg = 0d;
        while (pq.Count > 0)
        { 
            var clas = pq.Dequeue();
            maxAvg += (double)clas.passed / clas.students;
        }

        return maxAvg / classes.Length;
    }

    private double CalcGain(int passed, int students)
    {
        return ((passed + 1.0d) / (students + 1.0d)) - ((double)passed / students);
    }
}