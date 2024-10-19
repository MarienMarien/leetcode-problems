public class Solution {
    private IDictionary<char, char> MAP = 
        new Dictionary<char, char> { { '1', '0' }, { '0', '1' } };
    public char FindKthBit(int n, int k)
    {
        const char ONE = '1';
        var sb = new StringBuilder();
        sb.Append("0");
        for (var i = 1; i <= n; i++)
        {
            var invertedReverse = GetInvertedReverse(sb);
            sb.Append(ONE);
            sb.Append(invertedReverse);
        }

        return sb[k - 1];
    }

    private StringBuilder GetInvertedReverse(StringBuilder sN)
    {
        var sb = new StringBuilder();
        for (var i = sN.Length - 1; i >= 0; i--)
        {
            sb.Append(MAP[sN[i]]);
        }
        return sb;
    }
}