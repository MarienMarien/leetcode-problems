public class Solution {
    public IList<string> StringMatching(string[] words) {
        var result = new HashSet<string>();
        foreach(var word in words){
            foreach(var substring in words){
                if(word == substring || substring.Length > word.Length)
                    continue;
                if(word.Contains(substring))
                    result.Add(substring);
            }
        }
        return result.ToList();
    }
}