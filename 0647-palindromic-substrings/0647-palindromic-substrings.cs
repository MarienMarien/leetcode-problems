public class Solution {
    public int CountSubstrings(string s) {
        var count = 0;
        for (var i = 0; i < s.Length; i++)
        {
            count += CountPalindroms(s, i, i);

            count += CountPalindroms(s, i, i + 1);
        }

        return count;
    }

    private int CountPalindroms(string s, int left, int right)
    {
        var start = left;
        var end = right;

        var count = 0;
        while (start >= 0 && end < s.Length)
        {
            if (s[start] != s[end])
                break;
            start--;
            end++;
            count++;
        }

        return count;
    }
}