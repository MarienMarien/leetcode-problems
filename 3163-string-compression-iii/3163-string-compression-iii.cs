public class Solution {
    public string CompressedString(string word) {
        var wId = 0;
        var counter = 0;
        var sb = new StringBuilder();
        var prevChar = word[0];
        while(wId < word.Length)
        {
            prevChar = word[wId];
            while(wId < word.Length && word[wId] == prevChar && counter < 9)
            {
                wId++;
                counter++;
            }
            sb.Append(counter).Append(prevChar);
            counter = 0;
        }

        return sb.ToString();
    }
}