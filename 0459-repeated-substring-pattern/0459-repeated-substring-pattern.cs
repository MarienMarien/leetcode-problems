public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        var len = s.Length;
        for (var i =  len / 2; i >= 1; i--)
        {
            if (len % i == 0) {
                var partLen = len / i;
                var str = s[0..i];
                var sb = new StringBuilder();
                for (var j = 0; j < partLen; j++) {
                    sb.Append(str);
                }
                if (sb.ToString() == s)
                    return true;
            }
        }
        return false;
    }
}