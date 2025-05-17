public class Solution {
    public void ReverseWords(char[] s) {
        Reverse(s, 0, s.Length - 1);
        for(var i = 0; i < s.Length; i++)
        {
            var wStart = i;
            var wEnd = i;
            while(i < s.Length && s[i] != ' ')
            {
                wEnd = i;
                i++;
            }
            Reverse(s, wStart, wEnd);
        }
    }

    private void Reverse(char[] s, int start, int end)
    {
        while(start < end)
        {
            var tmp = s[start];
            s[start] = s[end];
            s[end] = tmp;
            start++;
            end--;
        }
    }
}