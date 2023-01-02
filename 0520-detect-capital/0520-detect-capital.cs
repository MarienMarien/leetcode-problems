public class Solution {
    public bool DetectCapitalUse(string word) {
        if(word.Length == 1)
            return true;
        if(word.Length >= 2 && (char.IsLower(word[0]) && char.IsUpper(word[1])))
            return false;
        var check = char.IsLower(word[1]);
        for(var i = 1; i < word.Length; i++){
            if(char.IsLower(word[i]) != check)
                return false;
        }
        return true;
    }
}