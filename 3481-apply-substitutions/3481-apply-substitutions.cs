public class Solution {
    private const char PLACEHOLDER_START = '%';
    public string ApplySubstitutions(IList<IList<string>> replacements, string text) {
        var replacementMap = new Dictionary<char, string>();
        foreach(var r in replacements)
        {
            replacementMap.Add(r[0][0], r[1]);
        }

        
        var sb = new StringBuilder();
        var parts = text.Split('_');
        for(var i = 0; i < parts.Length; i++)
        {
            var p = parts[i];
            var replacement = GetReplacement(p[1], replacementMap);
            sb.Append(replacement);
            if(i < parts.Length - 1)
                sb.Append('_');
        }

        return sb.ToString();
    }

    private string GetReplacement(char key, IDictionary<char, string> replacementMap)
    {
        var replacement = replacementMap[key];
        var placeholderId = replacement.IndexOf(PLACEHOLDER_START);
        if(placeholderId == -1)
            return replacement;

        var sb = new StringBuilder();
        var start = 0;
        var end = replacement.Length - 1;
        for(var i = 0; i < replacement.Length; i++)
        {
            var currCh = replacement[i];
            if(currCh != PLACEHOLDER_START)
            {
                sb.Append(currCh);
                continue;
            }
            var inner = GetReplacement(replacement[i + 1], replacementMap);
            sb.Append(inner);
            i += 2;
        }
        return sb.ToString();       
    }
}