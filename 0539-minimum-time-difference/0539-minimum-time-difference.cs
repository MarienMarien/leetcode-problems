public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        var secondsPoints = new List<int>();
        foreach (var t in timePoints)
        {
            var splitted = t.Split(':');
            var hour = Int32.Parse(splitted[0]);
            var sec = Int32.Parse(splitted[1]);
            var seconds = hour * 60 + sec;
            secondsPoints.Add(seconds);
            if(hour < 12)
                secondsPoints.Add((hour + 24) * 60 + sec);
        }
        secondsPoints = secondsPoints.Order().ToList();
        var minDiff = Int32.MaxValue;
        for (var i = 1; i < secondsPoints.Count; i++)
        {
            minDiff = Math.Min(minDiff, secondsPoints[i] - secondsPoints[i - 1]);
        }

        return minDiff;
    }
}