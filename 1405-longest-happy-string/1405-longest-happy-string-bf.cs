public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        const char A = 'a';
        const char B = 'b';
        const char C = 'c';
        var sb = new StringBuilder();
        var q = new PriorityQueue<(char ch, int count), int>(Comparer<int>.Create((x, y) => y - x));
        if(a > 0)
            q.Enqueue((A, a), a);
        if(b > 0)
            q.Enqueue((B, b), b);
        if(c > 0)
            q.Enqueue((C, c), c);

        while (q.Count > 0)
        {
            var strLen = sb.Length;
            if (strLen > 1 && q.Peek().ch == sb[strLen - 1]
                && sb[strLen - 1] == sb[strLen - 2])
            {
                var excessChar = q.Dequeue();
                if (q.Count == 0)
                    break;
                var nextGoodChar = q.Dequeue();
                sb.Append(nextGoodChar.ch);

                q.Enqueue(excessChar, excessChar.count);
                if(nextGoodChar.count > 1)
                    q.Enqueue((nextGoodChar.ch, nextGoodChar.count - 1), nextGoodChar.count - 1);

                continue;
            }

            var currItem = q.Dequeue();
            sb.Append(currItem.ch);
            if (currItem.count > 1)
                q.Enqueue((currItem.ch, currItem.count - 1), currItem.count - 1);
        }

        return sb.ToString();
    }
}