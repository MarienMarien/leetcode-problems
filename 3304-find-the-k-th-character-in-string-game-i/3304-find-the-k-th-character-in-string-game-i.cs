public class Solution {
    public char KthCharacter(int k) {
        var sb = new StringBuilder("a");
        while (sb.Length < k)
        {
            var currLen = sb.Length;
            for (var i = 0; i < currLen; i++)
            {
                var nextChar = sb[i] == 'z' ? 'a' : (char)(sb[i] + 1);
                sb.Append(nextChar);
                if (sb.Length == k)
                    break;
            }
        }

        return sb[k - 1];
    }
}