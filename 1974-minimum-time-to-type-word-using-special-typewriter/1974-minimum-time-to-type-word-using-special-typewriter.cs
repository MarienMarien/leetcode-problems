public class Solution {
    public int MinTimeToType(string word) {
        const char Z = 'z';
        const char A = 'a';
        const int AlphabetSize = 26;
        char currChar = A;
        int minTime = 0;
        foreach (char ch in word) {
            if (ch == currChar) {
                minTime += 1;
                continue;
            }
            int diff = Math.Abs(ch - currChar);
            minTime += Math.Min(diff, AlphabetSize - diff) + 1;
            Console.WriteLine($"diff: {diff}; time: {minTime}");
            currChar = ch;
        }
        return minTime;
    }
}