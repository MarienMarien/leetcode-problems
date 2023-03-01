public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        if (words.Count != words[0].Length)
            return false;
        var ans = true;
        var firstWordLen = words[0].Length;
        for (var wId = 0; wId < words.Count; wId++){
            if (words[wId].Length > firstWordLen) {
                return false;
            }
            for (var chId = wId; chId < firstWordLen; chId++) {
                if (!((words[chId].Length > wId && words[wId].Length > chId && words[wId][chId] == words[chId][wId])
                || (words[chId].Length <= wId && words[wId].Length <= chId)))
                        return false;
            }
        }
        return ans;
    }
}