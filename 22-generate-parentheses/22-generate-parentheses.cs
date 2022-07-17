public class Solution {
    IList<string> res = new List<string>();
    string openParenth = "(";
    string closeParenth = ")";
    public IList<string> GenerateParenthesis(int n) {
        var newN = (n * 2) - 2;
        Generate(newN, "", newN / 2, newN / 2);
            return res;
        }

    private void Generate(int n, string item, int open, int closed)
    {
        if (n <= 0) {
            if (open == 0 && closed == 0) {
                res.Add(openParenth + item + closeParenth);
            }
            return;
        }
        foreach (var c in openParenth + closeParenth)
        {
            var newOpen = open - (c + "" == openParenth ? 1 : 0);
            var newClosed = closed;
            if (c + "" == closeParenth)
                if (open > closed)
                    break;
                else
                    newClosed--;

            Generate(n - 1, item + c, newOpen, newClosed);
        }
        return;
    }
}