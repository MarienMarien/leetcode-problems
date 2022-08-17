public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        var morseAlphabet = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
        var transformations = new HashSet<string>();
        foreach (var w in words) {
            var sb = new StringBuilder();
            for (var i = 0; i < w.Length; i++) {
                sb.Append(morseAlphabet[w[i] - 'a']);
            }
            var tmp = sb.ToString();
            if (!transformations.Contains(tmp))
            transformations.Add(tmp);
        }

        return transformations.Count;
    }
}