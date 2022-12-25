public class Solution {
    private Dictionary<int, int> _map = new Dictionary<int, int>{ { 0, 0 }, { 1, 1 }, { 2, 5 }, { 5, 2 }, { 6, 9 }, { 8, 8 }, { 9, 6 } };
    public int RotatedDigits(int n)
    {
        var count = 0;
        var curr = 1;
        while (curr <= n) {
            if(IsGood(curr))
                count++;
            curr++;
        }
        return count;
    }

    private bool IsGood(int n)
    {
        var curr = n;
        var rotated = 0;
        var koef = 1;
        while (curr > 0) {
            var digit = curr % 10;
            if (!_map.ContainsKey(digit))
                return false;
            rotated += _map[digit] * koef;
            koef *= 10;
            curr /= 10;
        }
        return rotated != n;
    }
}