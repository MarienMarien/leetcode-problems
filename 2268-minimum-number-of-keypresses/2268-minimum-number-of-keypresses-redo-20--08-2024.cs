public class Solution {
    public int MinimumKeypresses(string s) {
        var alphabet = new int[26];
        var count = 0;
        foreach (var ch in s)
        {
            alphabet[ch - 'a']++;
        }

        Array.Sort(alphabet, Comparer<int>.Create((x, y) => y - x));
        var counter = 9;
        var koef = 1;
        for (var i = 0; i < alphabet.Length; i++)
        {
            if (alphabet[i] == 0)
                break;
            counter--;

            count += alphabet[i] * koef;

            if (counter == 0)
            {
                koef++;
                counter = 9;
            }
        }

        return count;
    }
}