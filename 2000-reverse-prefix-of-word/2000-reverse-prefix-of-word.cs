public class Solution {
    public string ReversePrefix(string word, char ch) {
        int id = 0;
        while (id < word.Length) {
            if (word[id] == ch) {
                break;
            }
            id++;
        }
        if (id < word.Length) {
            StringBuilder sb = new StringBuilder();
            for(int reverseId = id; reverseId >= 0; reverseId--) {
                sb.Append(word[reverseId]);
            }
            for (int i = id + 1; i < word.Length; i++) {
                sb.Append(word[i]);
            }
            return sb.ToString();
        }
        return word;
    }
}