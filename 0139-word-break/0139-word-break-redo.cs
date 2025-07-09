public class Solution {
    private IDictionary<int, bool> _cache;
    private ISet<string> _dict;
    public bool WordBreak(string s, IList<string> wordDict) {
        _cache = new Dictionary<int, bool>();
        _dict = new HashSet<string>(wordDict);
        return CanConstruct(s, 0);
    }

    private bool CanConstruct(string s, int id)
    {
        if(id >= s.Length)
            return true;
        if(_cache.ContainsKey(id))
            return _cache[id];
        if(_dict.Contains(s))
            return true;
        for(var i = id + 1; i <= s.Length; i++)
        {
            var chunk = s[id..i];
            var canConstruct = _dict.Contains(chunk) && CanConstruct(s, i);
            _cache[id] = canConstruct;
            if(canConstruct)
                return true;
        }
        return false;
    }
}