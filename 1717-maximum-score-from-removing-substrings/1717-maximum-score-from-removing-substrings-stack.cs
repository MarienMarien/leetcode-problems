public class Solution {
    private int _score;
    public int MaximumGain(string s, int x, int y)
    {
        var higherScore = x > y ? x : y;
        var higherScoreCombination = higherScore == x ? "ab" : "ba";
        var lowerScore = higherScore == x ? y : x;
        var lowerScoreCombination = higherScore == x ? "ba" : "ab";

        var newS = CalcScore(s, higherScore, higherScoreCombination);
        var _ = CalcScore(newS, lowerScore, lowerScoreCombination);

        return _score;
    }

    private string CalcScore(string s, int scorePoints, string combination)
    {
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (ch == combination[1] && stack.Count > 0 && stack.Peek() == combination[0])
            {
                _score += scorePoints;
                stack.Pop();
                continue;
            }
            stack.Push(ch);
        }

        var newS = new char[stack.Count];
        for (var i = newS.Length - 1; i >= 0; i--)
        {
            newS[i] = stack.Pop();
        }

        return new string(newS);
    }
}