public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2) 
    {
        var trie = new Trie();
        foreach (var a in arr1)
        {
            trie.Insert(a.ToString());
        }

        var maxLen = 0;
        foreach (var a in arr2)
        {
            maxLen = Math.Max(maxLen, trie.GetPrefixLength(a.ToString()));
        }

        return maxLen;
    }

    public class Trie {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string number)
        {
            var node = _root;
            foreach (var n in number)
            {
                if (!node.ContainsKey(n))
                {
                    node.Put(n, new TrieNode());
                }
                node = node.Get(n);
            }
        }

        public int GetPrefixLength(string number)
        {
            var prefixLen = 0;
            var node = _root;
            
            foreach (var n in number)
            {
                if (!node.ContainsKey(n))
                {
                    break;
                }
                prefixLen++;
                node = node.Get(n);
            }

            return prefixLen;
        }
    }

    public class TrieNode
    {
        private TrieNode[] _links;
        private const int _size = 10;

        public TrieNode()
        {
            _links = new TrieNode[_size];
        }

        public bool ContainsKey(char ch)
        {
            return _links[ch - '0'] != null;
        }

        public TrieNode Get(char ch)
        {
            return _links[ch - '0'];
        }

        public void Put(char ch, TrieNode node)
        {
            _links[ch - '0'] = node;
        }
    }
}