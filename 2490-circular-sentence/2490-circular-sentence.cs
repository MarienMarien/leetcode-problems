public class Solution {
    public bool IsCircularSentence(string sentence) {
        if(sentence[0] != sentence[^1])
            return false;
        for(var i = 0; i < sentence.Length; i++)
        {
            if(sentence[i] == ' ' && sentence [i - 1] != sentence[i + 1])
            {
                return false;
            }
        }
        return true;
    }
}