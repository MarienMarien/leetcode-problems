public class Solution {
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
        var map = new Dictionary<int, (string target, int len)>();
        for(var i = 0; i < indices.Length; i++) {
            if (s.IndexOf(sources[i], indices[i]) == indices[i]) {
                map.Add(indices[i], (targets[i], sources[i].Length));
            }
        }
        var sb = new StringBuilder();
        var id = 0;
        while(id < s.Length){
            if (map.ContainsKey(id))
            {
                sb.Append(map[id].target);
                id += map[id].len;
            }
            else {
                sb.Append(s[id]);
                id++;
            }
        }
        return sb.ToString();
    }
}