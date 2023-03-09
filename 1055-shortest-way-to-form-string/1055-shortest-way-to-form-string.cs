public class Solution {
    public int ShortestWay(string source, string target) {
        var counter = 1;
        var sourceId = 0;
        var targetd = 0;
        var sourceSet = new HashSet<char>(source.ToCharArray());

        while (targetd < target.Length)
        {

            if (!sourceSet.Contains(target[targetd]))
            {
                return -1;
            }

            if (sourceId == source.Length)
            {
                counter++;
                sourceId = 0;
            }
            if (source[sourceId] == target[targetd])
            {
                targetd++;
            }
            sourceId++;
        }
        return counter;
    }
}