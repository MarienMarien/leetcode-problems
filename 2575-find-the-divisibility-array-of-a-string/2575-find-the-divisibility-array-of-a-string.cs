public class Solution {
    public int[] DivisibilityArray(string word, int m) {
        var divisibility = new int[word.Length];
        long number = 0;
        for(var i = 0; i < word.Length; i++)
        {
            number = (number * 10 + (word[i] - '0')) % m;
            if (number == 0)
                divisibility[i] = 1;
        }
        return divisibility;
    }
}