public class Solution {
    public int MinOperations(string[] logs) {
        const string up = "../";
        const string same = "./";
        var upCount = 0;
        var folderCount = 0;
        foreach(var l in logs)
        {
            if(l.Equals(same))
                continue;
            if(l.Equals(up))
            {
                if(folderCount > 0)
                folderCount--;
            }
            else
            {
                folderCount++;
            }
        }

        var diff = folderCount - upCount;

        return diff < 0 ? 0 : diff;
    }
}