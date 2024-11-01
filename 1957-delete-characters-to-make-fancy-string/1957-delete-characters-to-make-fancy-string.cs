public class Solution {
    public string MakeFancyString(string s) {
        var sb = new StringBuilder();
        var repeatCount = 0;
        var prevCh = s[0];
        foreach(var ch in s)
        {
            if(ch == prevCh && repeatCount >= 2)
                continue;
            if(ch != prevCh)
            {
                repeatCount = 0;
                prevCh = ch;
            }
            sb.Append(ch);
            repeatCount++;
        }
        return sb.ToString();
    }
}