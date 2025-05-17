public class Solution {
    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        var wLen = words.Length;
        var fW = new int[wLen];
        for(var i = 0; i < wLen; i++)
        {
            var w = words[i];
            var alphabet = new int[26];
            var smallest = 26;
            foreach(var ch in w)
            {
                var key = ch - 'a';
                smallest = Math.Min(smallest, key);
                alphabet[key]++;
            }
            fW[i] = alphabet[smallest];
        }

        Array.Sort(fW);

        var qLen = queries.Length;
        var result = new int[qLen];
        for(var i = 0; i < qLen; i++)
        {
            var q = queries[i];
            var alphabet = new int[26];
            var smallest = 26;
            foreach(var ch in q)
            {
                var key = ch - 'a';
                smallest = Math.Min(smallest, key);
                alphabet[key]++;
            }

            result[i] = GetQueryResult(fW, alphabet[smallest]);
        }

        return result;
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