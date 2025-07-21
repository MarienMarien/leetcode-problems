public class Solution {
    private const char PLACEHOLDER_SEP = '%';
    private StringBuilder _sb;

    public string ApplySubstitutions(IList<IList<string>> replacements, string text) {
        var replacementMap = new Dictionary<string, string>();
        foreach(var r in replacements)
        {
            replacementMap.Add(r[0], r[1]);
        }

        _sb = new StringBuilder();
        
        ProcessText(replacementMap, text);
        return _sb.ToString();
    }

    private void ProcessText(Dictionary<string, string> replacementMap, string text)
    {
        string replacement = replacementMap.GetValueOrDefault(text, string.Empty);
        if(!string.IsNullOrEmpty(replacement))
        {
            if(replacement.IndexOf(PLACEHOLDER_SEP) == -1)
            {
                _sb.Append(replacement);
                return;
            }
            text = replacement;
        }

        for(var i = 0; i < text.Length; i++)
        {
            var ch = text[i];
            if(ch != PLACEHOLDER_SEP)
            {
                _sb.Append(ch);
                continue;
            }
            ProcessText(replacementMap, $"{text[i + 1]}");
            i += 2;
        }
    }
}