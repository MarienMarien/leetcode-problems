public class Solution {
    public bool ReportSpam(string[] message, string[] bannedWords) {
        var bannedWordsSet = new HashSet<string>(bannedWords);
        var bannedCount = 0;
        foreach(var word in message)
        {
            if(bannedWordsSet.Contains(word))
                bannedCount++;
            if(bannedCount >= 2)
                break;
        }
        return bannedCount >= 2;
    }
}