public class Solution {
    private Dictionary<int, int> _powers;
    public int GetKth(int lo, int hi, int k) {
        _powers = new Dictionary<int, int>();
        for (var curr = lo; curr <= hi; curr++) {
            if(!_powers.ContainsKey(curr))
                GetIntPower(curr);
        }
        var resultList = _powers.OrderBy(x => x.Value).ThenBy(x => x.Key);
        var count = 0;
        var result = -1;
        foreach (var r in resultList) {
            if (r.Key >= lo && r.Key <= hi)
                count++;
            if (count == k) {
                result = r.Key;
                break;
            }
        }
        return result;
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