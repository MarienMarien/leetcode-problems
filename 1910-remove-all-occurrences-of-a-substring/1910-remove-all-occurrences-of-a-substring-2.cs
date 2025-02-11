public class Solution {
    public string RemoveOccurrences(string s, string part) {
        // KMP
        var partLen = part.Length;
        var prevOccur = 0;
        var partId = 1;
        var longestBorder = new int[partLen];
        while (partId < partLen)
        {
            if (part[partId] == part[prevOccur])
            {
                prevOccur++;
                longestBorder[partId] = prevOccur;
                partId++;
                continue;
            }

            if (prevOccur == 0)
            {
                longestBorder[partId] = 0;
                partId++;
            }
            else 
            {
                prevOccur = longestBorder[prevOccur - 1];
            }
        }

        // rem. occur.
        var stack = new Stack<(char ch, int partId)>();
        partId = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == part[partId])
            {
                partId++;
                stack.Push((s[i], partId));

                if (partId == partLen)
                {
                    for (var j = 0; j < partLen; j++)
                        stack.Pop();
                    partId = stack.Count > 0 ? stack.Peek().partId : 0;
                }
            }
            else 
            {
                if (partId > 0)
                {
                    i--;
                    partId = longestBorder[partId - 1];
                }
                else 
                {
                    stack.Push((s[i], 0));
                }
            }
        }

        var res = new char[stack.Count];
        for (var i = res.Length - 1; i >= 0; i--)
        {
            res[i] = stack.Pop().ch;
        }

        return new string(res);
    }
}