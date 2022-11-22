public class Solution {
    public IList<string> GeneratePossibleNextMoves(string currentState) {
        IList<string> res = new List<string>();
        var arr = currentState.ToCharArray();
        for (var i = 0; i < currentState.Length - 1; i++) {
            if (currentState[i] == '+' && currentState[i] == currentState[i + 1]) {
                arr[i] = '-';
                arr[i + 1] = '-';
                res.Add(new string(arr));
                arr[i] = '+';
                arr[i + 1] = '+';
            }
        }
        return res;
    }
}