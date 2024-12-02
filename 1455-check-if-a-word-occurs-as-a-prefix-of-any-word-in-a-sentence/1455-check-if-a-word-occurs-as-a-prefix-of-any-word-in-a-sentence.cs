public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        var sentenceId = 0;
        var searchWordId = 0;
        var wordId = 1;

        while(sentenceId < sentence.Length)
        {
            var currChar = sentence[sentenceId];
            sentenceId++;
            if(char.IsWhiteSpace(currChar))
            {
                wordId++;
                searchWordId = 0;
                continue;
            }

            if(currChar == searchWord[searchWordId])
            {
                searchWordId++;
                if(searchWordId == searchWord.Length)
                    return wordId;
                continue;
            }
            
            while(sentenceId < sentence.Length && !char.IsWhiteSpace(sentence[sentenceId]))
            {
                sentenceId++;
            }
        }

        return -1;
    }
}