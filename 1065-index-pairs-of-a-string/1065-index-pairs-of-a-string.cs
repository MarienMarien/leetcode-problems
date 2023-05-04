public class Solution {
    public int[][] IndexPairs(string text, string[] words)
    {
        Trie trie= new Trie();
        foreach (string w in words) {
            trie.Insert(w);
        }
        IList<int[]> res = new List<int[]>();
        for (int i = 0; i < text.Length; i++) {
            TrieNode currNode = trie.GetRoot();
            for (int j = i; j < text.Length; j++) { 
                if (!currNode.ContainsKey(text[j])) {
                    break;
                }
                currNode = currNode.Get(text[j]);
                if (currNode.IsEnd())
                    res.Add(new int[] { i, j });
            }
        }
        return res.ToArray();
    }

    public class Trie {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word) {
            var node = _root;
            foreach (char ch in word) {
                if (!node.ContainsKey(ch)) {
                    node.Put(ch, new TrieNode());
                }
                node = node.Get(ch);
            }
            node.SetEnd();
        }

        public TrieNode GetRoot() {
            return _root;
        }
    }

    public class TrieNode {
        private IDictionary<char, TrieNode> _links;
        private bool _isEnd;
        public TrieNode()
        {
            _links = new Dictionary<char, TrieNode>();
        }

        public bool ContainsKey(char ch) {
            return _links.ContainsKey(ch);
        }

        public void Put(char ch, TrieNode node) {
            _links[ch] = node;
        }

        public TrieNode Get(char ch) {
            return _links[ch];
        }

        public bool IsEnd()
        {
            return _isEnd;
        }

        public void SetEnd() { 
            _isEnd = true;
        }
    }
}