public class Solution {
    private int _count;
    private IDictionary<int, int> _dict = new Dictionary<int, int>() { { 0, 0 }, { 1, 1 }, { 6, 9 }, { 8, 8 }, { 9, 6 } };
    private int _checkLimit = (int)Math.Pow(10, 9);
    private int _checkMaxInt = (int)Math.Pow(10, 8);

    public int ConfusingNumberII(int n)
    {
        _count = n == _checkLimit ? 1 : 0;
        CountNumbers(0, n);
        return _count;
    }

    private void CountNumbers(int curr, int n)
    {
        if (curr > n) {
            return;
        }
        foreach (var d in _dict.Keys)
        {
            curr += d;
            if (curr / _checkLimit > 0 && curr % 10 > 1)
                break;
            if (curr == 0)
                continue;
            if (curr > n)
                break;
            var rotated = Rotate(curr);
            if (rotated != curr)
            {
                _count++;
            }
            if (curr / _checkMaxInt == 0)
                CountNumbers(curr * 10, n);
            curr -= d;
        }
    }

    private int Rotate(int n) {
        int rotated = 0;
        while (n > 0) {
            rotated = rotated * 10 + _dict[n % 10];
            n /= 10;
        }
        return rotated;
    }
}