public class Solution {
    public void ReverseWords(char[] s) {
        Reverse(s, 0, s.Length - 1);
        var startId = 0;
        for (var i = 0; i < s.Length; i++) {
            if (s[i] == ' ') {
                Reverse(s, startId, i - 1);
                startId = i + 1;
            }
        }
        Reverse(s, startId, s.Length - 1);
    }

    private void Reverse(char[] s, int start, int end) {
        while (start < end) {
            var tmp = s[start];
            s[start] = s[end];
            s[end] = tmp;
            start++;
            end--;
        }
    }
}