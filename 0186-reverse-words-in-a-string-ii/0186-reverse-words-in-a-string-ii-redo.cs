public class Solution {
    public void ReverseWords(char[] s) {
        s = Reverse(s, 0, s.Length - 1);
        var start = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' || i == s.Length - 1)
            {
                var end = i == s.Length - 1 ? i : i - 1;
                s = Reverse(s, start, end);
                start = i + 1;
            }
        }
    }

    private char[] Reverse(char[] s, int start, int end)
    {
        while (start < end)
        {
            var tmp = s[start];
            s[start] = s[end];
            s[end] = tmp;
            start++;
            end--;
        }
        return s;
    }
}