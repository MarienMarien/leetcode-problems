public class Solution {
    public string ReorderSpaces(string text) {
        if (text.Length < 2)
            return text;
        var words = new List<string>();
        var spacesCount = 0;
        var sb = new StringBuilder();
        foreach (var ch in text) {
            if (ch == ' ')
            {
                if (sb.Length > 0) { 
                    words.Add(sb.ToString());
                    sb.Clear();
                }
                spacesCount++;
            }
            else
            {
                sb.Append(ch);
            }
        }
        if (sb.Length > 0)
        {
            words.Add(sb.ToString());
            sb.Clear();
        }
        var wCount = words.Count > 1 ? words.Count - 1 : 1;
        var spacesBetween = spacesCount / wCount;
        var extraSpaces = spacesCount % wCount;
        for (var i = 0; i < words.Count; i++) {
            sb.Append(words[i]);
            if(i < words.Count - 1 || i == 0)
                sb.Append(' ', spacesBetween);
        }
        if(extraSpaces > 0)
            sb.Append(' ', extraSpaces);
        return sb.ToString();
    }
}