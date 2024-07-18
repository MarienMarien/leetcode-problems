public class Solution {
    public string RemoveStars(string s) {
        var stack = new Stack<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '*')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        var charArr = new char[stack.Count];
        for (var i = charArr.Length - 1; i >= 0; i--)
        {
            charArr[i] = stack.Pop();
        }

        return new string(charArr);
    }
}