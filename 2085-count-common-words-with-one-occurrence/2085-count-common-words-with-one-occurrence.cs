public class Solution {
    public int CountWords(string[] words1, string[] words2) {
        var map = new Dictionary<string, int>();
        foreach(var w in words1){
            if(!map.ContainsKey(w)){
                map.Add(w, 1);
            } else {
                map[w] = 0;
            }
        }
        var count = 0;
        foreach(var w in words2){
            if(map.ContainsKey(w)){
                if(map[w] == 1){
                    map[w]++;
                    count++;
                } else if (map[w] > 0){// == 2
                    map[w] = 0;
                    count--;
                }
            }
        }
        return count;
    }
}