public class Solution {
    public int PrefixCount(string[] words, string pref) {
        var trie = new Trie();
        foreach (var w in words)
        {
            trie.Insert(w);
        }
        return trie.GetPrefixFreq(pref);
    }

    class Trie
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
                if (!node.Contains(ch))
                    node.Put(ch, new TrieNode());
                node = node.Get(ch);
                node.IncFreq();
            }
        }

        public int GetPrefixFreq(string pref)
        {
            var node = _root;
            foreach (var ch in pref)
            {
                if (!node.Contains(ch))
                    return 0;
                node = node.Get(ch);
            }
            return node.GetFreq();
        }
    }
    class TrieNode
    {
        private TrieNode[] _links;
        private int _freq;

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