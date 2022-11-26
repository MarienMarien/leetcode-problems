public class Solution {
    public int LongestPalindrome(string s) {
        var alphabet = new int[26 + 26];
        foreach(var ch in s){
            var koef = Char.IsLower(ch)? 'a' : 'A';
            var shift = Char.IsLower(ch)? 26 : 0;
            alphabet[ch - koef + shift]++;
        }
        var hasOdd = false;
        var count = 0;
        for(var i = 0; i < alphabet.Length; i++){
            if(alphabet[i] > 0){
                hasOdd = hasOdd || alphabet[i] % 2 != 0;
                var isOdd = alphabet[i] % 2 != 0;
                count += alphabet[i] - (isOdd ? 1 : 0);
            }
        }

        return count + (hasOdd ? 1 : 0);
    }
}