public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        var trie = new Trie();
        var splitted = $"{s1} {s2}".Split(" ");
        var uncommonWords = new HashSet<string>();
        foreach (var word in splitted)
        {
            var firstTimeInserted = trie.Insert(word);
            if (firstTimeInserted)
            {
                uncommonWords.Add(word);
            }
            else {
                uncommonWords.Remove(word);
            }
        }

        return uncommonWords.ToArray();
    }

    public class Trie {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public bool Insert(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.ContainsKey(ch))
                {
                    node.Put(ch, new TrieNode());
                }
                node = node.Get(ch);
            }

            if (node.IsEnd())
                return false;
            node.SetEnd();
            return true;
        }
    }

    public class TrieNode {
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

        public TrieNode Get(char ch) { 
            return _links[ch - 'a'];
        }

        public void Put(char ch, TrieNode node)
        {
            _links[ch - 'a'] = node;
        }

        public bool IsEnd() {
            return _isEnd;
        }

        public void SetEnd() { 
            _isEnd = true;
        }
    }
}