public class Solution {
    public IList<IList<int>> FindWinners(int[][] matches) {
        var winners = new SortedSet<int>();
        var looses = new SortedDictionary<int, int>();
        foreach (var match in matches) {
            if (!looses.ContainsKey(match[1]))
                looses.Add(match[1], 0);
            looses[match[1]]++;
            if (!looses.ContainsKey(match[0]))
                winners.Add(match[0]);
            if (winners.Contains(match[1]))
                winners.Remove(match[1]);
        }
        IList<IList<int>> res = new List<IList<int>>();
        res.Add(new List<int>(winners));
        var loosers = new List<int>();
        foreach (var loss in looses) { 
            if(loss.Value == 1)
                loosers.Add(loss.Key);
        }
        res.Add(loosers);
        return res;
    }
}