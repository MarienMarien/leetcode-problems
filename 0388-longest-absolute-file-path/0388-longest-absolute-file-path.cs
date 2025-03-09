public class Solution {
    public int LengthLongestPath(string input) {
        var pathParts = input.Split("\n");
        var stack = new Stack<string>();
        var currTabCount = -1;
        var currPathLen = 0;
        var maxPathLen = 0;
        
        for(var i = 0; i < pathParts.Length; i++)
        {
            (int tabCount, bool isFile) = GetInfo(pathParts[i]);
            var currPathPart = tabCount == 0? pathParts[i] : pathParts[i].Substring(tabCount);
            if(tabCount <= currTabCount)
            {

                for(var popCount = 0; popCount < currTabCount - tabCount + 1; popCount++)
                {
                    var popped = stack.Pop();
                    currPathLen -= popped.Length;
                }
                Console.WriteLine();
            }
            
            currTabCount = tabCount;
            stack.Push(currPathPart);
            currPathLen += currPathPart.Length;
            if(isFile)
            {
                maxPathLen = Math.Max(maxPathLen, currPathLen + stack.Count - 1);
            }
        }

        return maxPathLen;
    }
    
    private (int tabCount, bool isFile) GetInfo(string s)
    {
        var count = 0;
        var i = 0;
        for (; i < s.Length - 1; i++)
        {
            if (s[i] == '\t')
                count++;
            else
                break;
        }

        var isFile = false;
        for (; i < s.Length; i++)
        {
            if (s[i] == '.')
            {
                isFile = true;
                break;
            }
        }
        return (count, isFile);
    }
}