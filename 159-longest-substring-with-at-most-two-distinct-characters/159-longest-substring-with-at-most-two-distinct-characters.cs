public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if (s.Length < 3)
            return s.Length;
        var start = 0; 
        var end = 1;
        var max = 0;
        var nextStart = start;
        int secondLetterId = -1;
        var letterSet = new HashSet<char>();
        letterSet.Add(s[0]);
        while (end < s.Length) {
            if (!letterSet.Contains(s[end])) { 
                letterSet.Add(s[end]);
                if (letterSet.Count > 2)
                {
                    max = Math.Max(max, end - start);
                    var toDel = s[nextStart] == s[start] ? s[secondLetterId] : s[start];
                    letterSet.Remove(toDel);
                    secondLetterId = end;
                    start = nextStart;
                    //end++;
                }
                else
                    secondLetterId = end;
            }
            if (s[end] != s[nextStart])
                nextStart = end;
            end++;
        }
        max = Math.Max(max, end - start);
        return max;
    }
}