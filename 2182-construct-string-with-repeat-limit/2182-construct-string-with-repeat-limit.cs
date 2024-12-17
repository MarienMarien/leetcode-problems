public class Solution {
    public string RepeatLimitedString(string s, int repeatLimit) {
        var alphabet = new int[26];
        foreach (var ch in s)
        {
            alphabet[ch - 'a']++;
        }
        var sb = new StringBuilder();
        var alphaId = alphabet.Length - 1;
        while (alphaId >= 0)
        {
            if (alphabet[alphaId] == 0)
            {
                alphaId--;
                continue;
            }

            var count = Math.Min(repeatLimit, alphabet[alphaId]);
            for (var c = 0; c < count; c++)
            {
                sb.Append((char)(alphaId + 'a'));
                alphabet[alphaId]--;
            }

            if (alphabet[alphaId] > 0)
            {
                var divCharId = alphaId - 1;
                while (divCharId >= 0 && alphabet[divCharId] == 0)
                    divCharId--;
                if (divCharId < 0)
                    break;
                sb.Append((char)(divCharId + 'a'));
                alphabet[divCharId]--;
            }
            else {
                alphaId--;
            }

        }

        return sb.ToString();
    }
}