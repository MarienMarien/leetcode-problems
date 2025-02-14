public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var len = beginWord.Length;
        var combinations = new Dictionary<string, IList<string>>();
        foreach (var word in wordList)
        {
            for (var i = 0; i < len; i++)
            {
                var combination = word.Substring(0, i) + '*' + word.Substring(i + 1);
                if(!combinations.ContainsKey(combination))
                    combinations.Add(combination, new List<string>());
                combinations[combination].Add(word);
            }
        }

        var q = new Queue<(string word, int level)>();
        q.Enqueue((beginWord, 1));
        var visited = new HashSet<string> { beginWord };
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            for (var i = 0; i < len; i++)
            {
                var candidate = curr.word.Substring(0, i) + '*' + curr.word.Substring(i + 1);
                if (!combinations.ContainsKey(candidate))
                    continue;
                foreach (var transformation in combinations[candidate])
                {
                    if (transformation.Equals(endWord))
                        return curr.level + 1;
                    if (!visited.Contains(transformation))
                    {
                        visited.Add(transformation);
                        q.Enqueue((transformation, curr.level + 1));
                    }
                }
            }
        }

        return 0;
    }
}