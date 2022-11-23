public class Solution {
    public string[] FindWords(string[] words) {
        var row1 = "qwertyuiop";
        var row2 = "asdfghjkl";
        var row3 = "zxcvbnm";
        var dict = new Dictionary<char, int>();
        foreach (var ch in row1) {
            dict.Add(ch, 1);
        }
        foreach (var ch in row2)
        {
            dict.Add(ch, 2);
        }
        foreach (var ch in row3)
        {
            dict.Add(ch, 3);
        }
        var res = new List<string>();
        foreach (var word in words) {
            var wRow = dict[char.ToLower(word[0])];
            foreach (var ch in word) {
                if (wRow != dict[char.ToLower(ch)]) {
                    wRow = -1;
                    break;
                }
            }
            if (wRow > 0) {
                res.Add(word);
            }
        }

        return res.ToArray();
    }
}