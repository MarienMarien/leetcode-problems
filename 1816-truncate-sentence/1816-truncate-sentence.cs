public class Solution {
    public string TruncateSentence(string s, int k) {
        var sb = new StringBuilder();
        var i = 0;
        while(i < s.Length && k > 0){
            if(s[i] == ' '){
                k--;
            }
            if(k > 0)
                sb.Append(s[i]);
            i++;
        }
        return sb.ToString();
    }
}