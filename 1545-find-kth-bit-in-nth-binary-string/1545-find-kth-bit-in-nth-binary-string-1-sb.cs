public class Solution {
    public char FindKthBit(int n, int k) {
        var map = new Dictionary<char, char> { { '1', '0' }, { '0', '1' } };
        const char ONE = '1';
        var sb = new StringBuilder();
        sb.Append("0");
        for (var i = 2; i <= n; i++)
        {
            var startPos = sb.Length - 1;
            sb.Append(ONE);
            for (var j = startPos; j >= 0; j--)
            {
                sb.Append(map[sb[j]]);
            }
        }

        return sb[k - 1];
    }
}