public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var text = new List<string>();

        var lineWords = new List<string>();
        var lineWordsLen = 0;

        for (var i = 0; i < words.Length; i++)
        {
            var currentLineLen = lineWordsLen + lineWords.Count - 1 + words[i].Length;
            if (currentLineLen >= maxWidth)
            {
                var spacesToPlaceInLine = maxWidth - lineWordsLen;
                var wordsToPlace = lineWords.Count - 1;
                var sb = new StringBuilder();
                sb.Append(lineWords[0]);
                if (lineWords.Count == 1)
                    sb.Append(' ', spacesToPlaceInLine);
                for (var j = 1; j < lineWords.Count; j++)
                {
                    var spaceCount = (int)Math.Ceiling((double)spacesToPlaceInLine / wordsToPlace);
                    sb.Append(' ', spaceCount);
                    sb.Append(lineWords[j]);
                    wordsToPlace--;
                    spacesToPlaceInLine -= spaceCount;
                }
                text.Add(sb.ToString());
                lineWords = new List<string>() { words[i] };
                lineWordsLen = words[i].Length;
            }
            else {
                lineWords.Add(words[i]);
                lineWordsLen += words[i].Length;
            }
        }

        if (lineWords.Count > 0)
        {
            var lastLine = new StringBuilder();
            lastLine.Append(lineWords[0]);
            for (var i = 1; i < lineWords.Count; i++)
            {
                lastLine.Append(' ');
                lastLine.Append(lineWords[i]);
            }
            lastLine.Append(' ', maxWidth - lastLine.Length);
            text.Add(lastLine.ToString());
        }

        return text;
    }
}