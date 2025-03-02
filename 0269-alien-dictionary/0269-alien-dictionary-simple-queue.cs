public class Solution {
    public string AlienOrder(string[] words) {
        var indegree = new Dictionary<char, int>();
        var adjList = new Dictionary<char, IList<char>>();

        foreach (var w in words)
        {
            foreach (var ch in w)
            {
                indegree[ch] = 0;
                adjList[ch] = new List<char>();

            }
        }

        for (var i = 1; i < words.Length; i++)
        {
            if (words[i - 1].Length > words[i].Length && words[i - 1].StartsWith(words[i]))
                return string.Empty;

            for (var j = 0; j < Math.Min(words[i].Length, words[i - 1].Length); j++)
            {
                if (words[i - 1][j] != words[i][j])
                {
                    indegree[words[i][j]]++;
                    adjList[words[i - 1][j]].Add(words[i][j]);
                    break;
                }
            }

        }

        var q = new Queue<char>();
        foreach (var e in indegree)
        {
            if (e.Value == 0)
            {
                q.Enqueue(e.Key);
            }
        }

        var sb = new StringBuilder();
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            sb.Append(curr);
            foreach (var adj in adjList[curr])
            {
                indegree[adj]--;
                if (indegree[adj] == 0)
                    q.Enqueue(adj);
            }
        }

        if (sb.Length != indegree.Count)
            return string.Empty;
        return sb.ToString();
    }
}