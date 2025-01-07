public class Solution {
    public IList<string> StringMatching(string[] words)
    {
        var trie = new Trie();
        foreach (var w in words)
        {
            trie.Insert(w);
        }

        var matched = new List<string>();
        foreach (var w in words)
        {
            if (trie.IsSubstring(w))
            {
                matched.Add(w);
            }
        }
        return matched;
    }

    class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string s)
        {
            for(var start = 0; start < s.Length; start++)
            {
                var node = _root;
                for (var i = start; i < s.Length; i++)
                {
                    if (!node.Contains(s[i]))
                        node.Put(s[i], new TrieNode());
                    node = node.Get(s[i]);
                    node.IncFreq();
                }
            }
        }

        public bool IsSubstring(string s)
        {
            var node = _root;
            foreach (var ch in s)
            {
                node = node.Get(ch);
                if (node.GetFreq() == 1)
                    return false;
            }
            return true;
        }

    }

    class TrieNode
    {
        private int _freq;
        private TrieNode[] _links;

        public TrieNode()
        {
            _links = new TrieNode[26];
        }

        public bool Contains(char ch)
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

        public void IncFreq()
        {
            _freq++;
        }

        public int GetFreq()
        {
            return _freq;
        }

    }
}