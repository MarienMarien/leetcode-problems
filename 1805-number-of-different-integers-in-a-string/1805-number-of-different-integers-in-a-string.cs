public class Solution {
    public int NumDifferentIntegers(string word) {
        var set = new HashSet<string>();
        var sb = new StringBuilder();
        for (var i = 0; i < word.Length; i++) {
            if (char.IsDigit(word[i]))
            {
                sb.Append(word[i]);
            }
            else {
                if (sb.Length > 0)
                {
                    var s = sb.ToString();
                    if (s.Length > 1) {
                        s = s.TrimStart('0');
                        if (s.Length == 0)
                            s = "0";
                    }
                    if(!set.Contains(s))
                        set.Add(s);
                    sb.Clear();
                }
            }
        }
        if (sb.Length > 0)
        {
            var s = sb.ToString();
            if (s.Length > 1)
            {
                s = s.TrimStart('0');
                if (s.Length == 0)
                    s = "0";
            }
            if (!set.Contains(s))
                set.Add(s);
        }
        return set.Count;
    }
}