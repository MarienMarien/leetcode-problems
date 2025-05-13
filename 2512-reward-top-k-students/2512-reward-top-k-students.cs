public class Solution {
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k) {
        var feedbackToPoints = new Dictionary<string, int>();
        foreach(var f in positive_feedback)
        {
            feedbackToPoints.TryAdd(f, 3);
        }

        foreach(var f in negative_feedback)
        {
            feedbackToPoints.TryAdd(f, -1);
        }

        var studentPoints = new PriorityQueue<int, (int st_id, int points)>(
            Comparer<(int stId, int points)>.Create((x, y) => x.points == y.points ? x.stId - y.stId : y.points - x.points)
        );
        var studentsCount = student_id.Length;
        for(var i = 0; i < studentsCount; i++)
        {
            var currStudentId = student_id[i];
            var reportEntry = report[i];
            var reportWords = reportEntry.Split(' ');
            var currStudentPoints = 0;
            foreach(var w in reportWords)
            {
                if(!feedbackToPoints.ContainsKey(w))
                    continue;
                currStudentPoints += feedbackToPoints[w];
            }
            studentPoints.Enqueue(currStudentId, (currStudentId, currStudentPoints));
        }

        var topKStudents = new List<int>();
        for(var i = 0; i < k; i++)
        {
            topKStudents.Add(studentPoints.Dequeue());
        }

        return topKStudents;
    }
}