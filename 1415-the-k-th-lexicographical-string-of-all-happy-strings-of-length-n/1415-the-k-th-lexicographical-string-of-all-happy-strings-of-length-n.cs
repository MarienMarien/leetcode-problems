public class Solution {
    private int _k;
    private char[] _alphabet = new char[] { 'a', 'b', 'c' };

    public string GetHappyString(int n, int k) {
        _k = k;
        var happyString = new char[n];
        return GenerateHappyString(happyString, 0);
    }

    private string GenerateHappyString(char[] happyStr, int currId)
    {
        if(currId >= happyStr.Length)
        {
            _k--;
            if(_k == 0)
                return new string(happyStr);
            return string.Empty;
        }

        foreach(var ch in _alphabet)
        {
            if(currId > 0 && ch == happyStr[currId - 1])
                continue;
            happyStr[currId] = ch;
            var currHappyStr = GenerateHappyString(happyStr, currId + 1);
            if(!string.IsNullOrEmpty(currHappyStr))
                return currHappyStr;
        }
        return string.Empty;
    }
}