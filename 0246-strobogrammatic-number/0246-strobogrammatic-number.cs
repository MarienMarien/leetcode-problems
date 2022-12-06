public class Solution {
    public bool IsStrobogrammatic(string num) {
        var map = new Dictionary<char, char>{{'0','0'}, {'1','1'}, {'6','9'}, {'8', '8'},{'9', '6'}};
        var sb = new StringBuilder();
        foreach(var n in num){
            if(!map.ContainsKey(n))
                return false;
            sb.Insert(0, map[n]);
        }
        return num == sb.ToString();
    }
}