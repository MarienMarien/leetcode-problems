public class Solution {
    public string LongestWord(string[] words)
    {
        Array.Sort(words);
        var trie = new Trie();
        foreach (var w in words)
        {
            trie.Insert(w);
        }

        var longestWord = string.Empty;
        foreach (var w in words)
        {
            if (!trie.HasAllPrefixes(w))
                continue;
            if (w.Length > longestWord.Length)
                longestWord = w;
        }
        return longestWord;
    }

    public class Trie 
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
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
            node.SetEnd();
        }

        public bool HasAllPrefixes(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                node = node.Get(ch);
                if (node == null || !node.IsEnd())
                    return false;
            }
            return true;
        }
    }

    public class TrieNode
    {
        private TrieNode[] _links;
        private const int _size = 26;
        private bool _isEnd;
        public TrieNode()
        {
            _links = new TrieNode[_size];
        }

        public bool ContainsKey(char ch)
        {
            return _links[ch - 'a'] != null;
        }

        public void Put(char ch, TrieNode node)
        {
            _links[ch - 'a'] = node;
        }

        public TrieNode Get(char ch)
        {
            return _links[ch - 'a'];
        }

        public bool IsEnd()
        {
            return _isEnd;
        }

        public void SetEnd()
        { 
            _isEnd = true;
        }
    }
}