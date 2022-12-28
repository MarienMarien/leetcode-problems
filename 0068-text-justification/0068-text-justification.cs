public class Solution {
    private IList<string> result;
    public IList<string> FullJustify(string[] words, int maxWidth) {
        result = new List<string>();
        var q = new Queue<string>();
        q.Enqueue(words[0]);
        var currLen = words[0].Length;
        var currSpaces = 0;
        for (var wId = 1; wId < words.Length; wId++) {
            var widthLeft = maxWidth - (currLen + currSpaces) - 1;
            if (widthLeft >= words[wId].Length)
            {
                q.Enqueue(words[wId]);
                currSpaces++;
                currLen += words[wId].Length;
            }
            else {
                CombineLine(q, currSpaces, currLen, maxWidth);
                q.Enqueue(words[wId]);
                currSpaces = 0;
                currLen = words[wId].Length;
            }
        }
        if (q.Count > 0)
        {
            CombineLine(q, currSpaces, currLen, maxWidth, true);
        }
        return result;
    }

    private void CombineLine(Queue<string> q, int currSpaces, int currLen, int maxWidth, bool isLeftJustified = false)
    {
        if(q.Count == 0)
            return;
        var wordsCount = q.Count;
        var sb = new StringBuilder();
        sb.Append(q.Dequeue());
        if (q.Count == 0) {
            sb.Append(' ', maxWidth - currLen);
            result.Add(sb.ToString());
            return;
        }
        var spaceLeft = maxWidth - (currLen + currSpaces) + currSpaces;
        var additionalSpaces = spaceLeft % currSpaces;
        var spaceCount = isLeftJustified ? 1 : spaceLeft / currSpaces;
        while (q.Count > 0) {
            var currSpaceCount = spaceCount;
            if (additionalSpaces > 0 && !isLeftJustified)
            {
                currSpaceCount++;
                additionalSpaces--;
            }
            sb.Append(' ', currSpaceCount);
            sb.Append(q.Dequeue());
        }
        if (isLeftJustified)
            sb.Append(' ', spaceLeft - (wordsCount - 1));
        result.Add(sb.ToString());
    }
}