public class Solution {
    public int CalculateTime(string keyboard, string word) {
        var alphabet = new Dictionary<char, int>();
        for(var id = 0; id < keyboard.Length; id++){
            alphabet.Add(keyboard[id], id);
        }
        var time = 0;
        var curr = 0;
        for(var id = 0; id < word.Length; id++){
            time += Math.Abs(curr - alphabet[word[id]]);
            curr = alphabet[word[id]];
        }
        return time;
    }
}