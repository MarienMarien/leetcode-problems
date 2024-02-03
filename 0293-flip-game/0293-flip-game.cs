public class Solution {
    public IList<string> GeneratePossibleNextMoves(string currentState) {
        var ans = new List<string>();
        var sb = new StringBuilder(currentState);
        var dict = new Dictionary<char, char> { { '+', '-' }, { '-', '+' } };

        for (var i = 1; i < currentState.Length; i++) {
            if (sb[i] == '+' && sb[i] == sb[i - 1])
            {
                sb[i] = dict[sb[i]];
                sb[i - 1] = dict[sb[i - 1]];
                ans.Add(sb.ToString());
                sb[i] = dict[sb[i]];
                sb[i - 1] = dict[sb[i - 1]];
            }
        }

        return ans;
    }
}