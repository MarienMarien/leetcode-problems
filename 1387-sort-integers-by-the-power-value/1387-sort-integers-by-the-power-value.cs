public class Solution {
    private Dictionary<int, int> _powers;
    public int GetKth(int lo, int hi, int k) {
         _powers = new Dictionary<int, int>();
        var resultList = new List<int[]>();
        for (var curr = lo; curr <= hi; curr++)
        {
            if (!_powers.TryGetValue(curr, out int power))
                power = GetIntPower(curr);
            resultList.Add(new int[] { curr, power });
        }
        resultList.Sort(Comparer<int[]>.Create((x, y) => { return x[1] == y[1] ? x[0] - y[0] : x[1] - y[1]; }));
        return resultList[k - 1][0];
    }

    private int GetIntPower(int curr)
    {
        if(_powers.ContainsKey(curr))
            return _powers[curr];
        if (curr == 1)
        {
            _powers[curr] = 0;
            return 0;
        }
        var nextCurr = curr;
        if (curr % 2 == 0)
        {
            nextCurr /= 2;
        }
        else {
            nextCurr = 3 * nextCurr + 1;
        }
        var power = GetIntPower(nextCurr) + 1;
        _powers[curr] = power;
        return power;
    }
}