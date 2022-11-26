public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var root = new Trie();
        foreach (var p in products) {
            root.Insert(p);
        }
        var sb = new StringBuilder();
        IList<IList<string>> res = new List<IList<string>>();
        for(var i = 0; i < searchWord.Length; i++) {
            sb.Append(searchWord[i]);
            var suggestions = root.GetSuggestions(sb.ToString(), 3);
            res.Add(suggestions);
        }
        return res;
    }

    internal class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }
        public void Insert(string word) {
            var node = _root;
            foreach (var ch in word) {
                if (!node.ContainsKey(ch)) {
                    node.Put(ch, new TrieNode());
                }
                node = node.Get(ch);
            }
            node.SetEnd();
        }

        public bool StartsWith(string prefix) {
            var node = SearchPrefix(prefix);
            return node != null;
        }

        internal IList<string> GetSuggestions(string prefix, int count)
        {
            IList<string> suggestions = new List<string>();
            var node = SearchPrefix(prefix);
            return RetrieveSuggestions(node, count, suggestions, new StringBuilder(prefix));
        }

        private IList<string> RetrieveSuggestions(TrieNode node, int threshold, IList<string> suggestions, StringBuilder sb)
        {
            if (node == null)
                return suggestions;
            if(node.IsEnd())
                suggestions.Add(sb.ToString());
            for (var i = 0; i < 26; i++) {
                if (suggestions.Count >= threshold)
                    break;
                    var key = (char)(i + 'a');
                if (node.ContainsKey(key)) {
                    sb.Append(key);
                    suggestions = RetrieveSuggestions(node.Get(key), threshold, suggestions, sb);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            return suggestions;
        }

        public bool Search(string word) {
            var node = SearchPrefix(word);
            return node != null && node.IsEnd();
        }

        private TrieNode SearchPrefix(string prefix) {
            var node = _root;
            foreach (var ch in prefix) {
                if (node.ContainsKey(ch))
                {
                    node = node.Get(ch);
                }
                else
                    return null;
            }
            return node;
        }
    }

    internal class TrieNode
    {
        private TrieNode[] _links;
        private bool _isEnd;
        private const int _linksCount = 26;

        public TrieNode()
        {
            _links = new TrieNode[_linksCount];
        }

        public bool ContainsKey(char ch) {
            return _links[ch - 'a'] != null;
        }
        public void Put(char ch, TrieNode node) { 
            _links[ch - 'a'] = node;
        }

        public TrieNode Get(char ch) {
            return _links[ch - 'a'];
        }

        public bool IsEnd() {
            return _isEnd;
        }

        public void SetEnd() {
            _isEnd = true;
        }
    }
}