public class Solution {
    private IList<string> _sentences;
    private IDictionary<string, int> _synonymIndexes;
    private IDictionary<int, ISet<string>> _synonymGroups;
    private UnionFind _uf;

    public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
    {
        _synonymIndexes = new Dictionary<string, int>();
        var index = 0;
        foreach (var pair in synonyms)
        {
            foreach(var s in pair)
            if (!_synonymIndexes.ContainsKey(s))
            {
                _synonymIndexes.Add(s, index++);
            }
        }

        _uf = new UnionFind(index);
        foreach (var pair in synonyms)
        {
            _uf.Union(_synonymIndexes[pair[0]], _synonymIndexes[pair[1]]);
        }

        _synonymGroups = new Dictionary<int, ISet<string>>();
        foreach (var synonym in _synonymIndexes)
        {
            var groupNo = _uf.Find(synonym.Value);
            if (!_synonymGroups.ContainsKey(groupNo))
                _synonymGroups.Add(groupNo, new SortedSet<string>(Comparer<string>.Create((x, y) => {
                    if (char.IsUpper(x[0]) && char.IsLower(y[0]))
                        return -1;
                    else if (char.IsLower(x[0]) && char.IsUpper(y[0]))
                        return 1;
                    return x.CompareTo(y);
                })));
            _synonymGroups[groupNo].Add(synonym.Key);
        }

        _sentences = new List<string>();
        var textWords = text.Split(" ");
        GenerateAlternativeSentences(textWords, 0);

        return _sentences;
    }

    private void GenerateAlternativeSentences(string[] textWords, int startFrom)
    {
        if(startFrom >= textWords.Length)
        {
            _sentences.Add(string.Join(" ", textWords));
            return;
        }

        for (var i = startFrom; i < textWords.Length; i++)
        {
            if (!_synonymIndexes.ContainsKey(textWords[i]))
                continue;
            var wordIndex = _synonymIndexes[textWords[i]];
            var groupNo = _uf.Find(wordIndex);
            foreach (var synonym in _synonymGroups[groupNo])
            {
                textWords[i] = synonym;
                GenerateAlternativeSentences(textWords, i + 1);
            }
            return;
        }
        _sentences.Add(string.Join(" ", textWords));
    }

    class UnionFind
    {
        private int[] _parents;
        private int[] _ranks;
        public UnionFind(int n)
        {
            _parents = new int[n];
            _ranks = new int[n];
            for (var i = 0; i < n; i++)
            {
                _parents[i] = i;
            }
        }

        public int Find(int n)
        {
            if (_parents[n] != n)
                _parents[n] = Find(_parents[n]);
            return _parents[n];
        }
        public void Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);

            if (parentA == parentB)
                return;
            if (_ranks[parentA] > _ranks[parentB])
                _parents[parentB] = parentA;
            else
                _parents[parentA] = parentB;

            if (_ranks[parentA] == _ranks[parentB])
                _ranks[parentB]++;
        }
    }
}