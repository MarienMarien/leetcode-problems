public class Solution {
    public string SimplifyPath(string path) {
        var dirs = path.Split('/');
        var stack = new Stack<string>();
        foreach (var dir in dirs) {
            if (dir == "." || dir == string.Empty)
                continue;
            if (dir == "..") {
                if(stack.Count > 0)
                    stack.Pop();
                continue;
            }
            stack.Push(dir);
        }
        var sb = new StringBuilder();
        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop());
            sb.Insert(0, "/");
        }
        if (sb.Length == 0)
            sb.Append("/");
        return sb.ToString();
    }
}