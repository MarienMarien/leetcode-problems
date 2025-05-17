public class Solution {
    public string ReverseWords(string s) {
        var sb = new StringBuilder();
        var start = 0;
        while(start < s.Length && s[start] == ' ')
            start++;
        var end = s.Length - 1;
        while(end >= 0 && s[end] == ' ')
            end--;
        for(var id = start; id <= end; id++)
        {
            if(s[id] == ' ' && s[id] == s[id - 1])
                continue;
            sb.Append(s[id]);
        }
        
        Reverse(sb, 0, sb.Length - 1);
        for(var i = 0; i < sb.Length; i++)
        {
            var revFrom = i;
            var revTo = i;
            while(i < sb.Length && sb[i] != ' ')
            {
                revTo = i;
                i++;
            }
            Reverse(sb, revFrom, revTo);
        }
        return sb.ToString();
    }

    private void Reverse(StringBuilder sb, int start, int end)
    {
        while(start < end)
        {
            var tmp = sb[start];
            sb[start] = sb[end];
            sb[end] = tmp;
            start++;
            end--;
        }
    }
}