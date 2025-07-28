public class Solution {
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
        var k = indices.Length;
        var map = new Dictionary<int, int>();
        for(var i = 0; i < k; i++)
        {
            var src = sources[i];
            var ind = indices[i];
            var candidateLastId = ind + src.Length;
            if(candidateLastId > s.Length)
                continue;
            var substr = s[ind..candidateLastId];
            if(src.Equals(substr))
                map[ind] = i;
        }
        var sb = new StringBuilder();
        for(var i = 0; i < s.Length; i++)
        {
            if(!map.ContainsKey(i))
            {
                sb.Append(s[i]);
                continue;
            }
            var id = map[i];
            var target = targets[id];
            sb.Append(target);
            var srcLen = sources[id].Length;
            i += srcLen - 1;
        }
        return sb.ToString();
    }
}