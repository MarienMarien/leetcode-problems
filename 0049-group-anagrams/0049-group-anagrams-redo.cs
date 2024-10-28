public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var groups = new Dictionary<string, IList<string>>();
        foreach(var s in strs)
        {
            var sortedS = s.ToCharArray();
            Array.Sort(sortedS);
            var sorted = new string(sortedS);
            if(!groups.TryAdd(sorted, new List<string>{ s }))
                groups[sorted].Add(s);
        }
        return groups.Values.ToList();
    }
}