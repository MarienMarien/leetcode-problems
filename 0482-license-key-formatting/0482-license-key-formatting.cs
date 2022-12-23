public class Solution {
    public string LicenseKeyFormatting(string s, int k) {
        var sb = new StringBuilder();
        var alphaCount = 0;
        foreach(var ch in s)
            if(char.IsLetterOrDigit(ch))
                alphaCount++;
        var currCount = 0;
        for(var i = s.Length - 1; i >= 0; i--) {
            if(s[i] == '-')
                continue;
            sb.Insert(0, char.ToUpper(s[i]));
            alphaCount--;
            if(alphaCount == 0)
                break;
            currCount++;
            if(currCount == k){
                currCount = 0;
                sb.Insert(0, '-');
            }
        }
        return sb.ToString();
    }
}