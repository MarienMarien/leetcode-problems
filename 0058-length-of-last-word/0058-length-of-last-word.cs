public class Solution {
    public int LengthOfLastWord(string s) {
        var count = 0;
        var id = s.Length - 1;
        while(s[id] == ' ')
            id--;
        while(id >= 0 && s[id] != ' '){
            id--;
            count++;
        }
        return count;
    }
}