public class Solution {
    private int[] _result;
    private bool[] _placed;
    private int _len;
    private int _n;

    public int[] ConstructDistancedSequence(int n)
    {
        _n = n;
        _len = n * 2 - 1;
        _result = new int[_len];
        _placed = new bool[n + 1];
        FillResult(0);
        return _result;
    }

    // [5,3,1,4,3,5,2,4,2]
    private bool FillResult(int id)
    {
        while (id < _len && _result[id] != 0)
        {
            id++;
        }

        if (id == _len)
            return true;

        for (var num = _n; num >= 1; num--)
        {
            if (_placed[num])
                continue;
            if (num == 1)
            {
                _result[id] = 1;
                _placed[num] = true;
                if (FillResult(id + 1))
                    return true;
                _result[id] = 0;
                _placed[num] = false;
                continue;
            }
            var secondPlace = id + num;
            if (secondPlace < _len && _result[secondPlace] == 0)
            {
                _result[id] = num;
                _result[secondPlace] = num;
                _placed[num] = true;
                if (FillResult(id + 1))
                    return true;
                _result[id] = 0;
                _result[secondPlace] = 0;
                _placed[num] = false;
            }
        }

        return false;
    }
}