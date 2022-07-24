public class Solution {
    public string RemoveDuplicates(string s, int k) {
        var stack = new Stack<KeyValuePair<char, int>>();
        var sequenceLen = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (stack.Count == 0)
            {
                sequenceLen = 1;
                stack.Push(new KeyValuePair<char, int>(s[i], sequenceLen));
                continue;
            }
            var prevChar = stack.Peek();
            if (s[i] == prevChar.Key)
            {
                if (sequenceLen + 1 < k)
                {
                    sequenceLen++;
                    stack.Push(new KeyValuePair<char, int>(s[i], sequenceLen));
                }
                else {
                    while (stack.Count > 0 && stack.Peek().Key == prevChar.Key)
                    {
                        stack.Pop();
                    }
                    sequenceLen = 1;
                    if (stack.Count > 0)
                    {
                        sequenceLen = stack.Peek().Value;
                    }
                }
                continue;
            }
            sequenceLen = 1;
            stack.Push(new KeyValuePair<char, int>(s[i], 1));
        }

        var sb = new StringBuilder(0);
        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop().Key);
        }
        return sb.ToString();
    }
}