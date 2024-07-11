public class Solution {
    public string ReverseParentheses(string s)
    {
        var opens = new Stack<int>();
        var arr = s.ToCharArray();
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] == '(')
            {
                opens.Push(i);
            }
            else if (arr[i] == ')'){
                var start = opens.Pop();
                Reverse(arr, start, i);
            }
        }

        var sb = new StringBuilder();
        foreach (var ch in arr)
        {
            if (ch != '(' && ch != ')')
                sb.Append(ch);
        }
        return sb.ToString();
    }

    private void Reverse(char[] arr, int start, int end)
    {
        while (start < end)
        {
            var tmp = arr[start];
            arr[start++] = arr[end];
            arr[end--] = tmp;
        }
    }
}