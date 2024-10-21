public class Solution {
    private int _maxUniqueSubStrCount;
    private ISet<string> _subStrs;
    public int MaxUniqueSplit(string s)
    {
        _subStrs = new HashSet<string>();
        FindMaxSubUniqueStrs(s, 0);
        return _maxUniqueSubStrCount;
    }

    private void FindMaxSubUniqueStrs(string s, int startId)
    {
        if (_subStrs.Count + s.Length - startId <= _maxUniqueSubStrCount)
            return;

        if (startId == s.Length)
        {
            _maxUniqueSubStrCount = Math.Max(_maxUniqueSubStrCount, _subStrs.Count);
            return;
        }

        for (var i = startId; i < s.Length; i++)
        {
            var subStr = s[startId..(i + 1)];
            if (_subStrs.Contains(subStr))
                continue;
            _subStrs.Add(subStr);
            FindMaxSubUniqueStrs(s, i + 1);
            _subStrs.Remove(subStr);
        }
    }
}