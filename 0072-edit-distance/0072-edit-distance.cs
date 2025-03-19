public class Solution {
    private int?[,] _memo;
    public int MinDistance(string word1, string word2) {
        var m = word1.Length;
        var n = word2.Length;
        _memo = new int?[m + 1,n + 1];
        return GetMinDistance(word1, word2, m, n);
    }

    private int GetMinDistance(string word1, string word2, int w1Id, int w2Id)
    {
        if(w1Id == 0)
            return w2Id;
        if(w2Id == 0)
            return w1Id;
        if(_memo[w1Id, w2Id] != null)
            return _memo[w1Id, w2Id].Value;
        if(word1[w1Id - 1] == word2[w2Id - 1])
        {
            _memo[w1Id, w2Id] = GetMinDistance(word1, word2, w1Id - 1, w2Id - 1);
        } 
        else 
        {
            var opIfInsert = 1 + GetMinDistance(word1, word2, w1Id, w2Id - 1);
            var opIfDelete = 1 + GetMinDistance(word1, word2, w1Id - 1, w2Id);
            var opIfReplace = 1 + GetMinDistance(word1, word2, w1Id - 1, w2Id - 1);

            _memo[w1Id, w2Id] = Math.Min(opIfInsert, Math.Min(opIfDelete, opIfReplace));
        }
        return _memo[w1Id, w2Id].Value;
    }
}