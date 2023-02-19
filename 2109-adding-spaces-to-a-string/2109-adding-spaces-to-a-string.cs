public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        var sb = new StringBuilder();
        var sId = 0;
        for(var i = 0; i < s.Length;i++){
            if(sId < spaces.Length && i == spaces[sId]){
                sb.Append(' ');
                sId++;
            }
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}