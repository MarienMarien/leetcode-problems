public class Solution {
    private IList<string> _abbreviations;
    
    public IList<string> GenerateAbbreviations(string word)
    {
        _abbreviations = new List<string>();
        Generate(word, new List<string>(), word.Length, 0);
        return _abbreviations;
    }

    private void Generate(string word, List<string> list, int currPos, int abbreviationCoveredLen)
    {
        if (abbreviationCoveredLen == word.Length)
        {
            _abbreviations.Add(string.Join("", list));
            return;
        }

        var startCount = word.Length - abbreviationCoveredLen;

        if (list.Count == 0 || !char.IsDigit(list[^1][^1]))
        {
            for (var i = startCount; i > 0; i--)
            {
                var addToAbbr = 1;
                addToAbbr = i == 0 ? 1 : i;
                list.Add(addToAbbr.ToString());
                var newId = abbreviationCoveredLen + addToAbbr;
                Generate(word, list, newId, newId);
                list.RemoveAt(list.Count - 1);
            }
        }

        var letterId = currPos % word.Length;
        list.Add(word[letterId].ToString());
        Generate(word, list, letterId + 1, abbreviationCoveredLen + 1);
        list.RemoveAt(list.Count - 1);
    }
}