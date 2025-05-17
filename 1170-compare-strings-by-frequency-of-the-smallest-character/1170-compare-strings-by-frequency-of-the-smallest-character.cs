public class Solution {
    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        var wLen = words.Length;
        var fW = new int[wLen];
        for(var i = 0; i < wLen; i++)
        {
            fW[i] = GetSmallestCount(words[i]);
        }

        Array.Sort(fW);

        var qLen = queries.Length;
        var result = new int[qLen];
        for(var i = 0; i < qLen; i++)
        {
            var smallestCount = GetSmallestCount(queries[i]);
            result[i] = GetQueryResult(fW, smallestCount);
        }

        return result;
    }

    private int GetSmallestCount(string word)
    {
        var smallestCount = 0;
        var smallest = 26;
        foreach(var ch in word)
        {
            var chInt = ch - 'a';
            if(chInt < smallest)
            {
                smallest = chInt;
                smallestCount = 1;
            } 
            else if(chInt == smallest)
            {
                smallestCount++;
            }
        }
        return smallestCount;
    }

    private int GetQueryResult(int[] fW, int fQ)
    {
        var len = fW.Length;
        var countLarger = 0;
        var start = 0;
        var end = fW.Length - 1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(fW[mid] <= fQ)
            {
                start = mid + 1;
            }
            else 
            {
                countLarger = len - mid;
                end = mid - 1;
            }
        }
        return countLarger;
    }
}