public class Solution {
    public string ClearDigits(string s) {
        var clearedChars = s.ToCharArray();
        var clearedId = 0;
        for(var i = 0; i < s.Length; i++)
        {
            if(char.IsDigit(s[i]))
            {
                clearedId--;
                continue;    
            }
            clearedChars[clearedId] = clearedChars[i];
            clearedId++;
        }
        return clearedId < 0 ? string.Empty : new string(clearedChars, 0, clearedId);
    }
}