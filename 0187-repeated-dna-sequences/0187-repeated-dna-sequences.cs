public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
         var dnaLen = 10;
        var set = new Dictionary<string, int>();
        var ans = new List<string>();
        for (var start = 0; start < s.Length - dnaLen + 1; start++) {
            var subs = s.Substring(start, dnaLen);
            if (set.ContainsKey(subs))
            {
                if(set[subs] == 1)
                    ans.Add(subs);
                set[subs]++;
            }
            else
                set.Add(subs, 1);
        }

        return ans;
    }
}