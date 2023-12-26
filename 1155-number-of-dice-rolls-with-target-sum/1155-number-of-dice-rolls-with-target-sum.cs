public class Solution {
    private IDictionary<int, IDictionary<int, int>> _combinationsForSum;
    private const int MOD = (int)1e9 + 7;

    public int NumRollsToTarget(int n, int k, int target)
    {
        _combinationsForSum = new Dictionary<int, IDictionary<int, int>>();
        return GetCombinationsCount(n, k, target);
    }

    private int GetCombinationsCount(int n, int k, int targetRem)
    {
        if (n == 0 || n == 1 && k < targetRem)
            return 0;

        if (_combinationsForSum.ContainsKey(targetRem) && _combinationsForSum[targetRem].ContainsKey(n))
        {
            return _combinationsForSum[targetRem][n] % MOD;
        }

        var combinationsNum = 0;
        
        for (var i = 1; i <= Math.Min(k, targetRem); i++) {
            var currRem = targetRem - i;
            if (n > 1)
            {
                combinationsNum = (combinationsNum + GetCombinationsCount(n - 1, k, currRem)) % MOD;
            }
            else
            {
                combinationsNum += currRem == 0 ? 1 : 0;
            }
        }

        if (!_combinationsForSum.ContainsKey(targetRem) || !_combinationsForSum[targetRem].ContainsKey(n)) {
            _combinationsForSum.TryAdd(targetRem, new Dictionary<int, int>());
            _combinationsForSum[targetRem].Add(n, combinationsNum);
        }

        return combinationsNum;
    }
}