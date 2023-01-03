public class Solution {
    public string ShiftingLetters(string s, int[] shifts) {
        var len = s.Length - 1;
        var currShift = 0;
        var newStr = new char[s.Length];
        for (var i = len; i >= 0; i--) { 
            var currCh = s[i];
            currShift = (currShift + shifts[i]) % 26;
            var newCh = (currCh - 'a' + currShift) % 26;
            newStr[i] = (char)(newCh + 'a');
        }
        return new string(newStr);
    }
}