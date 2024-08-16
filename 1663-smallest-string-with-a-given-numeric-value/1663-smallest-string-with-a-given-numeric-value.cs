public class Solution {
    public string GetSmallestString(int n, int k) {
        var str = new char[n];
        for (var i = n - 1; i >= 0; i--)
        {
            var currCh = Math.Min(k - i, 26);
            str[i] = (char)(currCh - 1 + 'a');
            k -= currCh;
        }

        return new string(str);
    }
}