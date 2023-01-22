public class Solution {
    public bool ValidWordAbbreviation(string word, string abbr) {
        if (abbr.Length > word.Length)
            return false;
        var abbrId = 0;
        var wId = 0;
        while(wId < word.Length && abbrId < abbr.Length){
            if (char.IsDigit(abbr[abbrId])) {
                if (abbr[abbrId] == '0')
                    return false;
                var start = abbrId;
                while (abbrId < abbr.Length && char.IsDigit(abbr[abbrId])) {
                    abbrId++;
                }
                var moveOn = Int32.Parse(abbr[start..abbrId]);
                wId += moveOn;
                continue;
            }
            if (word[wId] != abbr[abbrId])
                return false;
            abbrId++;
            wId++;
        }

        return wId == word.Length && abbrId == abbr.Length;
    }
}