public class Solution {
    public string ReverseWords(string s) {
        var sb = new StringBuilder();
        var wStart = 0;
        for (var i = 0; i < s.Length; i++) {
            if (s[i] == ' ') {
                for (var j = i - 1; j >= wStart; j--) {
                    sb.Append(s[j]);
                }
                sb.Append(' ');
                wStart = i + 1;
            }
        }
        for (var j = s.Length - 1; j >= wStart; j--)
        {
            sb.Append(s[j]);
        }
        return sb.ToString();
    }
}