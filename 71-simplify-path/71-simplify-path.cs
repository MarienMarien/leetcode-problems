public class Solution {
    public string SimplifyPath(string path) {
        if (path[0] != '/')
            return "";
        var stack = new Stack<char>();
        stack.Push(path[0]);
        var dotCount = 0;
        for (var i = 1; i < path.Length; i++) {
            if (path[i] == '/' && path[i - 1] == '/')
                continue;
            if (path[i] == '.' && (path[i - 1] == '/' || dotCount > 0)) {
                stack.Push(path[i]);
                dotCount++;
                if (i == path.Length - 1 && dotCount > 0 && dotCount < 3) {
                    // pop  dot 1
                    if (dotCount == 1)
                    {
                        stack.Pop();
                        if (stack.Count > 1)
                            // pop slash
                            stack.Pop();
                    }
                    if (dotCount == 2)
                    {
                        // pop  2 dots
                        stack.Pop();
                        stack.Pop();
                        if (stack.Count > 1)
                        {
                            // pop slash
                            stack.Pop();
                            // pop prev. item
                            while (stack.Peek() != '/')
                                stack.Pop();
                        }
                    }
                    dotCount = 0;
                    continue;
                }
                continue;
            }
            if (path[i] == '/' && dotCount > 0) {
                if (dotCount > 2) {
                    stack.Push(path[i]);
                    dotCount = 0;
                    continue;
                }
                if (dotCount == 2) {
                    // pop 2 dots
                    stack.Pop();
                    stack.Pop();
                    dotCount = 0;
                    if (stack.Count > 1)
                    {
                        // pop slash
                        stack.Pop();
                        // pop prev. item
                        while (stack.Peek() != '/')
                            stack.Pop();
                    }
                    continue;
                }
                if (dotCount == 1) {
                    stack.Pop();
                    dotCount = 0;
                    continue;
                }
            }
            if (dotCount > 0)
                dotCount = 0;
            stack.Push(path[i]);
        }
        if (stack.Count > 1 && stack.Peek() == '/')
            stack.Pop();

        var sb = new StringBuilder();
        while (stack.Count > 0) {
            sb.Insert(0, stack.Pop()) ;
        }
        return sb.ToString();
    }
}