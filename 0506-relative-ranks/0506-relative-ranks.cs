public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        var sortedScore = score.OrderByDescending(x => x).ToList();
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < sortedScore.Count; i++)
        {
            dict.Add(sortedScore[i], i + 1);
        }
        var placeNameMap = new Dictionary<int, string> { { 1, "Gold Medal" }, { 2, "Silver Medal" }, { 3, "Bronze Medal" } };

        var res = new string[score.Length];
        for (var i = 0; i < res.Length; i++)
        {
            var place = dict[score[i]];
            res[i] = placeNameMap.ContainsKey(place) ? placeNameMap[place] : place.ToString();
        }
        return res;
    }
}