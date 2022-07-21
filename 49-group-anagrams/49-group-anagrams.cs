public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        for (var i = 0; i < strs.Length; i++) {
            var currStrArr = strs[i].ToCharArray();
            Array.Sort(currStrArr);
            var sortedCurr = new string(currStrArr);
            if (!dict.ContainsKey(sortedCurr)) {
                dict.Add(sortedCurr, new List<string>());
            }
            dict[sortedCurr].Add(strs[i]);
        }
        return dict.Values.ToList();
    }
}